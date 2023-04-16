using System;

namespace TDDMicroExercises.TelemetrySystem;

public interface ITelemetryClient
{
    void Send(string message);
    string Receive();
}

public class TelemetryClient : ITelemetryClient
{
    public const string DiagnosticMessage = "AT#UD";
    private readonly IEventSimulator _eventSimulator;

    private string _diagnosticMessageResult = string.Empty;

    public TelemetryClient()
    {
        _eventSimulator = new EventSimulator();
    }

    public TelemetryClient(IEventSimulator eventSimulator)
    {
        _eventSimulator = eventSimulator;
    }

    public void Send(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ArgumentNullException();
        }

        if (message == DiagnosticMessage)
        {
            // simulate a status report
            _diagnosticMessageResult =
                "LAST TX rate................ 100 MBPS\r\n"
                + "HIGHEST TX rate............. 100 MBPS\r\n"
                + "LAST RX rate................ 100 MBPS\r\n"
                + "HIGHEST RX rate............. 100 MBPS\r\n"
                + "BIT RATE.................... 100000000\r\n"
                + "WORD LEN.................... 16\r\n"
                + "WORD/FRAME.................. 511\r\n"
                + "BITS/FRAME.................. 8192\r\n"
                + "MODULATION TYPE............. PCM/FM\r\n"
                + "TX Digital Los.............. 0.75\r\n"
                + "RX Digital Los.............. 0.10\r\n"
                + "BEP Test.................... -5\r\n"
                + "Local Rtrn Count............ 00\r\n"
                + "Remote Rtrn Count........... 00";
        }

        // here should go the real Send operation
    }

    public string Receive()
    {
        string message;

        if (string.IsNullOrEmpty(_diagnosticMessageResult) == false)
        {
            message = _diagnosticMessageResult;
            _diagnosticMessageResult = string.Empty;
        }
        else
        {
            // simulate a received message
            message = string.Empty;
            var messageLength = _eventSimulator.SimulateMessageLength();
            for (var i = messageLength; i >= 0; --i)
            {
                message += _eventSimulator.SimulateMessageSymbol();
            }
        }

        return message;
    }
}