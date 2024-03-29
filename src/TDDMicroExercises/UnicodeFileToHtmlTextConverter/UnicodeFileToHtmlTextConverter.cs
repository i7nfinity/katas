using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public class UnicodeFileToHtmlTextConverter
{
    private readonly IFileReader _fileReader;

    public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
    {
        _fileReader = new FileReader(fullFilenameWithPath);
    }

    public UnicodeFileToHtmlTextConverter(IFileReader fileReader)
    {
        _fileReader = fileReader;
    }

    public string GetFilename()
    {
        return _fileReader.GetFilename();
    }

    public string ConvertToHtml()
    {
        using TextReader unicodeFileStream = _fileReader.GetFileStream();
        var html = string.Empty;

        var line = unicodeFileStream.ReadLine();
        while (line != null)
        {
            html += HttpUtility.HtmlEncode(line);
            html += "<br />";
            line = unicodeFileStream.ReadLine();
        }

        return html;
    }
}

internal class HttpUtility
{
    public static string HtmlEncode(string line)
    {
        line = line.Replace("&", "&amp;");
        line = line.Replace("<", "&lt;");
        line = line.Replace(">", "&gt;");
        line = line.Replace("\"", "&quot;");
        line = line.Replace("\'", "&quot;");
        return line;
    }
}