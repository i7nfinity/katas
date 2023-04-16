using TDDMicroExercises.LeaderBoard;

namespace TDDMicroExercises.Leaderboard;

public class LeaderboardShould
{
    [Fact]
    public void SumThePoints()
    {
        Dictionary<string, int>? results = TestData.SampleLeaderboard1.DriverResults();
        Assert.True(results.ContainsKey("Lewis Hamilton"));
        Assert.Equal(18 + 18 + 25, results["Lewis Hamilton"]);
    }

    [Fact]
    public void FindTheWinner()
    {
        Assert.Equal("Lewis Hamilton", TestData.SampleLeaderboard1.DriverRankings()[0]);
    }

    [Fact]
    public void KeepAllDriversWhenSamePoints()
    {
        var winDriver1 = new Race("Australian Grand Prix", TestData.Driver1, TestData.Driver2, TestData.Driver3);
        var winDriver2 = new Race("Malaysian Grand Prix", TestData.Driver2, TestData.Driver1, TestData.Driver3);
        var exEquoLeaderBoard = new LeaderBoard.Leaderboard(winDriver1, winDriver2);

        List<string>? rankings = exEquoLeaderBoard.DriverRankings();

        Assert.Equal(
            new List<string> {TestData.Driver2.Name, TestData.Driver1.Name, TestData.Driver3.Name},
            rankings);
    }
}