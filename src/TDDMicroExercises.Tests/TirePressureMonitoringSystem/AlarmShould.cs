namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class AlarmShould
{
    [Fact]
    public void NoAlarmWithoutCheck()
    {
        var alarm = new Alarm();
        Assert.False(alarm.AlarmOn);
    }

    [Fact]
    public void GetAlarmIfLowPressure()
    {
        var sensor = new SensorSpy(16);
        var alarm = new Alarm(sensor);

        alarm.Check();

        Assert.True(alarm.AlarmOn);
    }

    [Fact]
    public void GetAlarmIfHighPressure()
    {
        var sensor = new SensorSpy(22);
        var alarm = new Alarm(sensor);

        alarm.Check();

        Assert.True(alarm.AlarmOn);
    }

    [Theory]
    [InlineData(17)]
    [InlineData(21)]
    public void NoAlarmIfNormalPressure(double pressure)
    {
        var sensor = new SensorSpy(pressure);
        var alarm = new Alarm(sensor);

        alarm.Check();

        Assert.False(alarm.AlarmOn);
    }
}