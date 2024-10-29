namespace Questao2;

public class Team
{
    public string TeamName { get; set; }
    
    public int Year { get; set; }
    
    public int TotalGoals { get; set; }

    public Team(string teamName, int year, int totalGoals)
    {
        TeamName = teamName;
        Year = year;
        TotalGoals = totalGoals;
        
        Console.WriteLine(ToString());
    }

    public override string ToString()
        => $"Team {TeamName} scored {TotalGoals} goals in {Year}";
}