using Newtonsoft.Json;
using Questao2;

public class Program
{
    public enum TeamOrder
    {
        Team1,
        Team2
    }
    
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        new Team(teamName, year, getTotalScoredGoals(teamName, year));

        teamName = "Chelsea";
        year = 2014;
        new Team(teamName, year, getTotalScoredGoals(teamName, year));
    }

    public static int getTotalScoredGoals(string team, int year)
    {
        string urlBase = $"https://jsonmock.hackerrank.com/api/football_matches?year={year}";
        
        int goalsT1 = GoalsTeamFromApi(urlBase+$"&team1={team}", TeamOrder.Team1);
        
        int goalsT2 = GoalsTeamFromApi(urlBase+$"&team2={team}", TeamOrder.Team2);

        return  goalsT1 + goalsT2;
    }

    public static int GoalsTeamFromApi(string url, TeamOrder teamOrder)
    {
        int totalGoals = 0;
        int currentPage = 1;
        int totalPages = 1;

        using (HttpClient client = new HttpClient())
        {
            while (currentPage <= totalPages)
            {
                HttpResponseMessage response = client.GetAsync(url+$"&page={currentPage}").GetAwaiter().GetResult();
                response.EnsureSuccessStatusCode();
                
                string jsonMessage = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var data = JsonConvert.DeserializeObject<ApiResponse>(jsonMessage);

                foreach (var match in data.Data)
                {
                    totalGoals += int.Parse(TeamOrder.Team1.Equals(teamOrder) ? match.Team1Goals : match.Team2Goals);
                }

                totalPages = data.TotalPages;
                currentPage++;
            }
        }
        return totalGoals;
    }

}