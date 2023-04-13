namespace TDDMicroExercises.UnicodeFileToHtmlTextConverter;

public class HikerTest
{
    [Fact]
    public void Foobar()
    {
        var converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
        Assert.Equal("foobar.txt", converter.GetFilename());
    }
}