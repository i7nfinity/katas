using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public class FileReader : IFileReader
{
    private readonly string _fullFilenameWithPath;

    public FileReader(string fullFilenameWithPath)
    {
        _fullFilenameWithPath = fullFilenameWithPath;
    }

    public string GetFilename()
    {
        return _fullFilenameWithPath;
    }

    public TextReader GetFileStream()
    {
        return File.OpenText(_fullFilenameWithPath);
    }
}