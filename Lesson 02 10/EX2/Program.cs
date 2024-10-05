namespace EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Война и мир", "Л. Толстой", BookFormat.Hardcover, BookGenre.Fiction);
            Book book2 = new Book("1984", "Дж. Оруел", BookFormat.Paperback, BookGenre.Fiction);
            Book book3 = new Book("S-T-I-K-S", "А. Кам`янистий", BookFormat.Hardcover, BookGenre.Fiction);

            Library.AddBook(book1);

            if (Library.TakeBook(book1))
            {
                Console.WriteLine("Книга выдана.");
            }

            Console.WriteLine($"Количество взятых книг: {Library.TotalBooksTaken}");
        }               
    }
    public enum BookFormat
    {
        Hardcover,
        Paperback,
        Ebook,
        Audiobook
    }

    public enum BookGenre
    {
        Fiction,
        NonFiction,
        Mystery,
        ScienceFiction
    }

    public class Book
    {
        public string Title { get; }
        public string Author { get; }
        public BookFormat Format { get; }
        public BookGenre Genre { get; }

        public Book(string title, string author, BookFormat format, BookGenre genre)
        {
            Title = title;
            Author = author;
            Format = format;
            Genre = genre;
        }
    }

    public static class LibraryConfig
    {
        public static readonly int MaxBooks = 1000; 
    }

    public static class Library
    {
        private static List<Book> _books = new List<Book>();
        private static int _booksTaken = 0;

        public static void AddBook(Book book)
        {
            if (_books.Count < LibraryConfig.MaxBooks)
            {
                _books.Add(book);
            }
            else
            {
                Console.WriteLine("Превышено максимальное количество книг в каталоге.");
            }
        }

        public static bool TakeBook(Book book)
        {
            if (_books.Remove(book))
            {
                _booksTaken++;
                return true;
            }
            else
            {
                Console.WriteLine("Книги нет в наличии.");
                return false;
            }
        }

        public static void ReturnBook(Book book)
        {
            _books.Add(book);
            _booksTaken--;
        }

        public static bool IsBookAvailable(Book book)
        {
            return _books.Contains(book);
        }

        public static int TotalBooksTaken => _booksTaken;
    }
}
