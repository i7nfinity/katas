using Moq;

namespace TDDMicroExercises.TelemetrySystem;

public class TelemetryDiagnosticControlsShould
{
    private readonly Mock<ITelemetryClient> _telemetryClientMock = new();
    private readonly Mock<ITelemetryConnection> _telemetryConnectionMock = new();

    [Fact]
    public void SendDiagnosticMessageAndReceiveStatusMessageResponse()
    {
        var telemetryDiagnosticControls = new TelemetryDiagnosticControls();

        telemetryDiagnosticControls.CheckTransmission();

        Assert.NotEmpty(telemetryDiagnosticControls.DiagnosticInfo);
    }

    [Fact]
    public void SendDiagnosticMessageAndReceiveExpectedStatusMessageResponse()
    {
        const string expectedStatusMessageResponse = "123";
        _telemetryConnectionMock.SetupGet(s => s.OnlineStatus).Returns(true);
        _telemetryClientMock.Setup(s => s.Send(TelemetryClient.DiagnosticMessage));
        _telemetryClientMock.Setup(s => s.Receive()).Returns(expectedStatusMessageResponse);

        var telemetryDiagnosticControls = new TelemetryDiagnosticControls(
            _telemetryConnectionMock.Object,
            _telemetryClientMock.Object);

        telemetryDiagnosticControls.CheckTransmission();

        Assert.Equal(expectedStatusMessageResponse, telemetryDiagnosticControls.DiagnosticInfo);
        _telemetryClientMock.Verify(v => v.Send(TelemetryClient.DiagnosticMessage), Times.Once);
        _telemetryClientMock.Verify(v => v.Receive(), Times.Once);
    }

    [Fact]
    public void ThrowExceptionIfUnableToConnect()
    {
        _telemetryConnectionMock.SetupGet(s => s.OnlineStatus).Returns(false);

        var telemetryDiagnosticControls = new TelemetryDiagnosticControls(
            _telemetryConnectionMock.Object,
            _telemetryClientMock.Object);

        Assert.Throws<Exception>(() => telemetryDiagnosticControls.CheckTransmission());

        _telemetryClientMock.Verify(v => v.Send(It.IsAny<string>()), Times.Never);
        _telemetryClientMock.Verify(v => v.Receive(), Times.Never);
    }
}