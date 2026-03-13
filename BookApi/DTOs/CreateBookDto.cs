public class CreateBookDto
{
    public string Title { get; set; }

    public string Author { get; set; }

    public string Isbn { get; set; }

    public DateOnly PublicationDate { get; set; }
}