namespace Enigpus.entities;

public class Novel : Book
{
    public string Author { get; set; }

    public override string GetTitle()
    {
        return Title;
    }
}