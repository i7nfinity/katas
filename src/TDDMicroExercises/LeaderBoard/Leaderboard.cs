using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard;

public class Leaderboard
{
    private readonly List<Race> _races = new();

    public Leaderboard(params Race[] races)
    {
        _races.AddRange(races);
    }

    public Dictionary<string, int> DriverResults()
    {
        var results = new Dictionary<string, int>();
        foreach (Race race in _races)
        {
            foreach (Driver driver in race.Results)
            {
                var driverName = race.GetDriverName(driver);
                var points = race.GetPoints(driver);
                if (results.ContainsKey(driverName))
                {
                    results[driverName] = results[driverName] + points;
                }
                else
                {
                    results.Add(driverName, 0 + points);
                }
            }
        }

        return results;
    }

    public List<string> DriverRankings()
    {
        Dictionary<string, int> results = DriverResults();
        var resultsList = new List<string>(results.Keys);
        resultsList.Sort();
        return resultsList;
    }
}