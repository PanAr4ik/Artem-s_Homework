namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Reader reader = new Reader("Моше", "Даян", 1948);
            
            Book book1 = new Book("Игра престолов", "Джорж Мартин", 1996, 834,  "Fantasy");
            Book book2 = new Book("Битва королей", "Джорж Мартин", 1998, 768,  "Fantasy");
            Book book3 = new Book("Ведьмак", "Сапковский", 1996, 640,  "Fantasy");
            Book book4 = new Book("C# 4.0 полное руководство", "Герберт Шилд", 2019, 1056,  "Програмироване");
            Book book5 = new Book("Грокаем алгоритмы", "Адитья Бхаргава", 2019, 1056,  "Програмироване");
        
            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                        
            var search_by_year = library.SearchByYear(1996);
            foreach(var book in search_by_year)
                Console.WriteLine(book._Title);
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var sortByYear = library.SortByYear();
            foreach (var book in sortByYear)
                Console.WriteLine(book._Title);

            Console.WriteLine();

            var searchByGanre = library.SearchByGenre("Програмироване");
            foreach (var book in searchByGanre)
                Console.WriteLine(book._Title);
            

            Console.WriteLine("\n\n----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            reader.BorrowBook("Игра престолов");

            Console.WriteLine("\n\n----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            reader.ReturnBookToLibrary("Игра престолов");
        }
    }

    public class Book
    {
        public string _Title;
        public string _Author;
        public int _YearOfPublication;
        public  int _PageCount;
        public string _Genre;

        public Book(string title, string author, int yearOfPublication, int pageCount, string genre)
        {
            _Title = title;
            _Author = author;
            _YearOfPublication = yearOfPublication;
            _PageCount = pageCount;
            _Genre = genre;
        }
    }

    public class Library
    {
        public static List<Book> booksList;

        public Library()
        {
            booksList = new List<Book>();
        }

        // Метод для добавления книги в библиотеку
        public void AddBook(Book book)
        {
            booksList.Add(book);
        }
        
        // Метод для сортировки книг по названию
        public List<Book> SortByTitle()
        {
            return booksList.OrderBy(book => book._Title).ToList();
        }
        
        // Метод для поиска книг по автору
        public List<Book> SearchByAuthor(string author)
        {
            return booksList.Where(book => book._Author == author).ToList();
        }
           
        // Метод для поиска книг по жанру
        public List<Book> SearchByGenre(string genre)
        {
            return booksList.Where(book => book._Genre == genre).ToList();
        }

        // Метод для поиска книг по году издания
        public List<Book> SearchByYear(int year)
        {
            return booksList.Where(book => book._YearOfPublication == year).ToList();
        }

        // Метод для сортировки книг по году издания
        public List<Book> SortByYear()
        {
            return booksList.OrderBy(book => book._YearOfPublication).ToList();
        }
    }
}
