using System;

namespace TDDMicroExercises.TelemetrySystem;

public interface IEventSimulator
{
    bool SimulateOnlineStatus();
    char SimulateMessageSymbol();
    int SimulateMessageLength();
}

public class EventSimulator : IEventSimulator
{
    private readonly Random _connectionEventsSimulator = new(42);

    public bool SimulateOnlineStatus()
    {
        return _connectionEventsSimulator.Next(1, 10) <= 8;
    }

    public char SimulateMessageSymbol()
    {
        return (char)_connectionEventsSimulator.Next(40, 126);
    }

    public int SimulateMessageLength()
    {
        return _connectionEventsSimulator.Next(50, 110);
    }
}