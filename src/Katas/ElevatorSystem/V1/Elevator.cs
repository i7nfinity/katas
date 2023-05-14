namespace Katas.ElevatorSystem.V1;

public sealed class Elevator
{
    private Floor _floor = Floor.Ground;
    public int FloorDiff { get; private set; }

    public void MoveTo(Floor nextFloor)
    {
        FloorDiff = Math.Abs(nextFloor - _floor);
        _floor = nextFloor;
    }
}