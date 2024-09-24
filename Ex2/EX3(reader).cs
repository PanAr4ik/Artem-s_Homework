using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public class Reader
    {
        public string name {  get; set; }
        public string surname {  get; set; }
        public int readerNumber {  get; set; }
        public List<Book> BorrowedBooks = new List<Book>();

        public Reader(string name, string surname, int readerNumbder)
        {
            this.name = name;
            this.surname = surname;
            this.readerNumber = readerNumbder;
        }

        public void BorrowBook(string bookTitle)
        {
            var bookInLibrary = Library.booksList.FirstOrDefault(book => book._Title == bookTitle);
            if (bookInLibrary != null) 
            {
                BorrowedBooks.Add(bookInLibrary);  
                Library.booksList.Remove(bookInLibrary);  

                Console.WriteLine("Книги в библиотеке");
                foreach (var i in Library.booksList)
                    Console.WriteLine(i._Title);
                Console.WriteLine("Книги у пользователя");
                foreach (var i in BorrowedBooks)
                    Console.WriteLine(i._Title);
            }
            else
            {
                Console.WriteLine("Этой книги нет в библиотеке."); 
            }
        }

        public void ReturnBookToLibrary(string bookTitle)
        {
            var readersBook = BorrowedBooks.FirstOrDefault(book => book._Title == bookTitle);
            if (readersBook != null)  
            {
                Library.booksList.Add(readersBook);  
                BorrowedBooks.Remove(readersBook);  

                Console.WriteLine("Книги в библиотеке");
                foreach (var i in Library.booksList)
                    Console.WriteLine(i._Title);
                Console.WriteLine("Книги у пользователя");
                foreach (var i in BorrowedBooks)
                    Console.WriteLine(i._Title);
            }
            else
            {
                Console.WriteLine("Этой книги нет у пользователя.");  
            }
        }
    }
}
