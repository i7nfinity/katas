namespace TDDMicroExercises.TirePressureMonitoringSystem;

public class AlarmTest
{
    [Fact]
    public void Foo()
    {
        var alarm = new Alarm();
        Assert.False(alarm.AlarmOn);
    }
}