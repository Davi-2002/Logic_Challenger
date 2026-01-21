namespace Logic_Challenger.Models;

public class ChallengeViewModel
{
    public string Question { get; set; } = string.Empty;
    public int Difficulty { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string Explanation { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}
