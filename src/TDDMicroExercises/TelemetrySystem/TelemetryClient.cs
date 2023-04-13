using System;

namespace TDDMicroExercises.TelemetrySystem;

public class TelemetryClient
{
    public const string DiagnosticMessage = "AT#UD";

    private readonly Random _connectionEventsSimulator = new(42);
    private string _diagnosticMessageResult = string.Empty;

    public bool OnlineStatus { get; private set; }

    public void Connect(string telemetryServerConnectionString)
    {
        if (string.IsNullOrEmpty(telemetryServerConnectionString))
        {
            throw new ArgumentNullException();
        }

        // simulate the operation on a real modem
        var success = _connectionEventsSimulator.Next(1, 10) <= 8;

        OnlineStatus = success;
    }

    public void Disconnect()
    {
        OnlineStatus = false;
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
            var messageLenght = _connectionEventsSimulator.Next(50, 110);
            for (var i = messageLenght; i >= 0; --i)
            {
                message += (char)_connectionEventsSimulator.Next(40, 126);
            }
        }

        return message;
    }
}