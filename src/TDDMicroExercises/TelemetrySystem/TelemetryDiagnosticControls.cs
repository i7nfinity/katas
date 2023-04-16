using System;

namespace TDDMicroExercises.TelemetrySystem;

public class TelemetryDiagnosticControls
{
    private const string DiagnosticChannelConnectionString = "*111#";
    private readonly ITelemetryClient _telemetryClient;

    private readonly ITelemetryConnection _telemetryConnection;

    public TelemetryDiagnosticControls()
    {
        _telemetryConnection = new TelemetryConnection();
        _telemetryClient = new TelemetryClient();
    }

    public TelemetryDiagnosticControls(ITelemetryConnection telemetryConnection, ITelemetryClient telemetryClient)
    {
        _telemetryConnection = telemetryConnection;
        _telemetryClient = telemetryClient;
    }

    public string DiagnosticInfo { get; private set; } = string.Empty;

    public void CheckTransmission()
    {
        DiagnosticInfo = string.Empty;

        _telemetryConnection.Disconnect();

        var retryLeft = 3;
        while (_telemetryConnection.OnlineStatus == false && retryLeft > 0)
        {
            _telemetryConnection.Connect(DiagnosticChannelConnectionString);
            retryLeft -= 1;
        }

        if (_telemetryConnection.OnlineStatus == false)
        {
            throw new Exception("Unable to connect.");
        }

        _telemetryClient.Send(TelemetryClient.DiagnosticMessage);
        DiagnosticInfo = _telemetryClient.Receive();
    }
}