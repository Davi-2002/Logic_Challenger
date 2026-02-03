namespace Logic_Challenger.Models;

public class ChallengeViewModel
{
    public string Question { get; set; } = "Aperte no botão abaixo para gerar um desafio lógico";
    public string Answer { get; set; } = string.Empty;
    public string Feedback { get; set; } = string.Empty;
    public int Difficulty { get; set; } = 1;
    public bool CreatedQuestion { get; set; } = false;
}
