using Logic_Challenger.Models;

namespace Logic_Challenger.Services;

public interface IChallengeGenService
{
    Task<ChallengeViewModel> GenerateChallenge();
}
