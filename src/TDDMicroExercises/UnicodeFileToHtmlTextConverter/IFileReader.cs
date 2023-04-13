using System.IO;

namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public interface IFileReader
{
    string GetFilename();
    TextReader GetFileStream();
}