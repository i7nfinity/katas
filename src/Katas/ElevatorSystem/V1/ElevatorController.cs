namespace Katas.ElevatorSystem.V1;

public sealed class ElevatorController
{
    private readonly Elevator _elevator = new();
    private readonly List<Floor> _stops = new();
    private int _timer;

    public void CallFrom(Floor fromFloor)
    {
        Call(fromFloor);
    }

    public void CallTo(Floor toFloor)
    {
        Call(toFloor);
    }

    private void Call(Floor destinationFloor)
    {
        _elevator.MoveTo(destinationFloor);
        _timer += _elevator.FloorDiff;
        _stops.Add(destinationFloor);
    }

    public int CalculateTimeInSeconds()
    {
        return (_stops.Count * 3) + _timer;
    }

    public string PrintStops()
    {
        return string.Join("->", _stops);
    }
}