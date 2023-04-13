using System.Collections.Generic;

namespace TDDMicroExercises.LeaderBoard;

public class Race
{
    private static readonly int[] Points = {25, 18, 15};
    private readonly string _name;

    public Race(string name, params Driver[] drivers)
    {
        _name = name;
        Results = new List<Driver>();
        Results.AddRange(drivers);

        foreach (Driver driver in Results)
        {
            var driverName = driver.Name;

            var drivingCar = driver as SelfDrivingCar;

            if (drivingCar != null)
            {
                driverName = "Self Driving Car - " + drivingCar.Country + " (" +
                             drivingCar.AlgorithmVersion + ")";
            }

            DriverNames.Add(driver, driverName);
        }
    }

    public List<Driver> Results { get; }

    public Dictionary<Driver, string> DriverNames { get; } = new();

    public int Position(Driver driver)
    {
        return Results.FindIndex(d => Equals(d, driver));
    }

    public int GetPoints(Driver driver)
    {
        return Points[Position(driver)];
    }

    public string GetDriverName(Driver driver)
    {
        return DriverNames[driver];
    }

    public override string ToString()
    {
        return _name;
    }
}