namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class Alarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;

    private readonly ISensor _sensor;

    public Alarm()
    {
        _sensor = new Sensor();
    }

    public Alarm(ISensor sensor)
    {
        _sensor = sensor;
    }

    public bool AlarmOn { get; private set; }

    public void Check()
    {
        var psiPressureValue = _sensor.PopNextPressurePsiValue();

        if (psiPressureValue is >= LowPressureThreshold and <= HighPressureThreshold)
        {
            return;
        }

        AlarmOn = true;
    }
}