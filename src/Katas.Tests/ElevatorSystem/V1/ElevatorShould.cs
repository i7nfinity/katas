using Katas.ElevatorSystem.V1;

namespace Katas.Tests.ElevatorSystem.V1;

public class ElevatorShould
{
    [Test]
    public void StartPositionIsOnTheGroundFloor()
    {
        var elevator = new Elevator();

        var actual = elevator.FloorDiff;

        Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void MoveToFloor3FromGround()
    {
        var elevator = new Elevator();
        elevator.MoveTo(Floor.Floor3);

        var actual = elevator.FloorDiff;

        Assert.That(actual, Is.EqualTo(3));
    }

    [Test]
    public void MoveToBasementFromFloor3()
    {
        var elevator = new Elevator();
        elevator.MoveTo(Floor.Floor3);
        elevator.MoveTo(Floor.Basement);

        var actual = elevator.FloorDiff;

        Assert.That(actual, Is.EqualTo(4));
    }
}