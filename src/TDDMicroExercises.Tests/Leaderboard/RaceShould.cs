namespace TDDMicroExercises.Leaderboard;

public class RaceShould
{
    [Fact]
    public void CalculateDriverPoints()
    {
        Assert.Equal(25, TestData.Race1.GetPoints(TestData.Driver1));
        Assert.Equal(18, TestData.Race1.GetPoints(TestData.Driver2));
        Assert.Equal(15, TestData.Race1.GetPoints(TestData.Driver3));
    }
}