namespace LibraryCardCatalog
{
   
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Published { get; set; }

        public Book()
        {

        }
        public Book(string title, string author, int published)
        {
            Title = title;
            Author = author;
            Published = published;
        }

        public override string ToString()
        {
            return $"Title is: {Title}, Author is: {Author}, Year is: {Published}";
        }
    }
}
