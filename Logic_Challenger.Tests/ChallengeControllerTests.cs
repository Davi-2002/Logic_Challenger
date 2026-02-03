using Logic_Challenger.Controllers;
using Logic_Challenger.Models;
using Logic_Challenger.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Logic_Challenger.Tests;

public class ChallengeControllerTests
{
    [Fact]
    public async Task GenerateTest_ReturnsViewResult_WithChallengeViewModel()
    {
        var mockServiceGen = new Mock<IChallengeGenService>();
        var Challenge = new ChallengeViewModel();
        mockServiceGen.Setup(g => g.GenerateChallenge(1)).ReturnsAsync(Challenge);
        var controller = new ChallengeController(mockServiceGen.Object);
        var resultAction = await controller.GenerateTest(1);
        var viewResult = Assert.IsType<ViewResult>(resultAction);
        Assert.Equal(Challenge, viewResult.Model);
    }

    [Fact]
    public async Task CheckAnswer_ReturnsViewResult_WithChallengeViewModel()
    {
        var mockServiceGen = new Mock<IChallengeGenService>();
        mockServiceGen.Setup(g => g.CheckAnswer("teste", "4", "2")).ReturnsAsync("resposta");
        var controller = new ChallengeController(mockServiceGen.Object);
        var resultAction = await controller.CheckAnswer("teste", "4", "2", 1);
        var viewResult = Assert.IsType<ViewResult>(resultAction);
        var model = Assert.IsType<ChallengeViewModel>(viewResult.Model);
        Assert.Equal("resposta", model.Feedback);   
    }

    [Fact]
    public void Index_ReturnsViewResult_WithChallengeViewModel()
    {
        var mockServiceGen = new Mock<IChallengeGenService>();
        var controller = new ChallengeController(mockServiceGen.Object);
        var resultAction = controller.Index();
        var viewResult = Assert.IsType<ViewResult>(resultAction);
        var model = Assert.IsType<ChallengeViewModel>(viewResult.Model);
        Assert.Equal(1, model.Difficulty);
        Assert.False(model.CreatedQuestion);
    }
}
