namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public class FileReaderSpy : IFileReader
{
    private readonly TextReader _textReader;

    public FileReaderSpy(string fakeText)
    {
        _textReader = new StringReader(fakeText);
    }

    public string GetFilename()
    {
        return string.Empty;
    }

    public TextReader GetFileStream()
    {
        return _textReader;
    }
}