namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public class UnicodeFileToHtmlTextConverterShould
{
    [Fact]
    public void ReturnFilename()
    {
        var converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
        Assert.Equal("foobar.txt", converter.GetFilename());
    }

    [Fact]
    public void ReturnEmptyForEmptyFile()
    {
        var fileReader = new FileReaderSpy("");
        var converter = new UnicodeFileToHtmlTextConverter(fileReader);

        var actual = converter.ConvertToHtml();

        Assert.Equal("", actual);
    }

    [Fact]
    public void ReturnEscapedAngleBracketsWithLineBreak()
    {
        var fileReader = new FileReaderSpy("2 > 1; 3 < 4");
        var converter = new UnicodeFileToHtmlTextConverter(fileReader);

        var actual = converter.ConvertToHtml();

        Assert.Equal("2 &gt; 1; 3 &lt; 4<br />", actual);
    }

    [Fact]
    public void ReturnEscapedAmpersandWithLineBreak()
    {
        var fileReader = new FileReaderSpy("a & b");
        var converter = new UnicodeFileToHtmlTextConverter(fileReader);

        var actual = converter.ConvertToHtml();

        Assert.Equal("a &amp; b<br />", actual);
    }

    [Fact]
    public void ReturnEscapedQuotesWithLineBreak()
    {
        var fileReader = new FileReaderSpy("\"a\" - 'b'");
        var converter = new UnicodeFileToHtmlTextConverter(fileReader);

        var actual = converter.ConvertToHtml();

        Assert.Equal("&quot;a&quot; - &quot;b&quot;<br />", actual);
    }
}