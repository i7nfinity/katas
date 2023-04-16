using System;

namespace TDDMicroExercises.TelemetrySystem;

public interface ITelemetryConnection
{
    bool OnlineStatus { get; }
    void Connect(string telemetryServerConnectionString);
    void Disconnect();
}

public class TelemetryConnection : ITelemetryConnection
{
    private readonly IEventSimulator _eventSimulator;

    public TelemetryConnection()
    {
        _eventSimulator = new EventSimulator();
    }

    public TelemetryConnection(IEventSimulator eventSimulator)
    {
        _eventSimulator = eventSimulator;
    }

    public bool OnlineStatus { get; private set; }

    public void Connect(string telemetryServerConnectionString)
    {
        if (string.IsNullOrEmpty(telemetryServerConnectionString))
        {
            throw new ArgumentNullException();
        }

        // simulate the operation on a real modem
        OnlineStatus = _eventSimulator.SimulateOnlineStatus();
    }

    public void Disconnect()
    {
        OnlineStatus = false;
    }
}