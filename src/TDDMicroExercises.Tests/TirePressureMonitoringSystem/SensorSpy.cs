namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class SensorSpy : ISensor
{
    private readonly double _pressure;

    public SensorSpy(double pressure)
    {
        _pressure = pressure;
    }

    public double PopNextPressurePsiValue()
    {
        return _pressure;
    }
}