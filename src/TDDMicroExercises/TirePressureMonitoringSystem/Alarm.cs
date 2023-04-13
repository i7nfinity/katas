namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class Alarm
{
    private const double LowPressureThreshold = 17;
    private const double HighPressureThreshold = 21;
    private long _alarmCount;

    private readonly Sensor _sensor = new();

    public bool AlarmOn { get; private set; }


    public void Check()
    {
        var psiPressureValue = _sensor.PopNextPressurePsiValue();

        if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
        {
            AlarmOn = true;
            _alarmCount += 1;
        }
    }
}