using Katas.ElevatorSystem.V1;

namespace Katas.Tests.ElevatorSystem.V1;

public class ElevatorControllerShould
{
    [Test]
    public void Calculate4SecondsToFloor1WithOneStop()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor1);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(4));
    }

    [Test]
    public void Calculate6SecondsToFloor3WithOneStop()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor3);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(6));
    }

    [Test]
    public void Calculate13SecondsToFloor3ToBasementWithTwoStops()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor3);
        elevatorController.CallTo(Floor.Basement);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(13));
    }

    [Test]
    public void Calculate17SecondsToFloor3ToBasementToGroundWithThreeStops()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor3);
        elevatorController.CallTo(Floor.Basement);
        elevatorController.CallFrom(Floor.Ground);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(17));
    }

    [Test]
    public void Calculate21SecondsToFloor3ToBasementToGroundWithThreeStops()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor3);
        elevatorController.CallTo(Floor.Basement);
        elevatorController.CallFrom(Floor.Ground);
        elevatorController.CallTo(Floor.Basement);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(21));
    }

    [Test]
    public void Calculate43SecondsToFullPathWithEightStops()
    {
        var elevatorController = new ElevatorController();
        elevatorController.CallFrom(Floor.Floor3);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Ground);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Floor2);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Floor1);
        elevatorController.CallTo(Floor.Floor3);

        var actual = elevatorController.CalculateTimeInSeconds();

        Assert.That(actual, Is.EqualTo(43));
    }

    [Test]
    public void PrintThreeElevatorStops()
    {
        var elevatorController = new ElevatorController();

        elevatorController.CallFrom(Floor.Floor3);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Ground);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Floor2);
        elevatorController.CallTo(Floor.Basement);

        elevatorController.CallFrom(Floor.Floor1);
        elevatorController.CallTo(Floor.Floor3);

        var actual = elevatorController.PrintStops();

        Assert.That(actual, Is.EqualTo("Floor3->Basement->Ground->Basement->Floor2->Basement->Floor1->Floor3"));
    }
}