/* Title: Machine Problem
 * Course: IT111L
 * Section: B54
 * Group No.: 2
 * Members: Tayag, Olivarez, Rapista, Marasigan, Gurion
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Group2_MachineProblem
{
    public class User
    {
        private string username;
        private string pin;
    
        public string Username
        {
            // Define getter and setters for username
            get { return username;  }
            set { username = value; }
        }

        public string Pin 
        {
            // Define getter and setters for pin
            get { return pin; }
            set { pin = value; }
        }
    }

    public class Book 
    {
        private string title;
        private string[] authors;
        private string publicationDate;
        private string edition;
        private string genre;
       
        public string Title
        {
            // Define getters and setters for title
            get { return title; }
            set { title = value; }
        }

        public string[] Authors
        {
            // Define getter and setter for authors
            get { return authors; }
            set { authors = value; }
        }

        public string PublicationDate
        {
            // Define getter and setter for publicationDate
            get { return publicationDate; }
            set { publicationDate = value; }
        }

        public string Edition
        {
            // Define getter and setter for edition
            get { return edition; }
            set { edition = value; }
        }

        public string Genre
        {
            // Define getter and setter for genre
            get { return genre; }
            set { genre = value; }
        }

    }

    public class Library
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        public List<Book> Books
        {
            // Define getter and setter for books
            get { return books; }
            set { books = value; }
        }
        public List<User> Users
        {
            // Define getter and setter for users
            get { return users; }
            set { users = value; }
        }
        public void DisplayBooks()
        {
            // This function displays all the books in the books list
            Console.WriteLine("|{0,-30}|{1,-30}|{2,-15}|{3,-10}|{4,-15}|", "Title", "Authors", "Date Published", "Edition", "Genre");
            for(int i=0; i<books.Count; i++)
            {
                string title = books[i].Title;
                string authors = string.Join(", ", books[i].Authors);
                string publishDate = books[i].PublicationDate;
                string edition = books[i].Edition;
                string genre = books[i].Genre;
                Console.WriteLine("|{0,-30}|{1,-30}|{2,-15}|{3,-10}|{4,-15}|", title, authors, publishDate, edition, genre);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Testing - TODO
            Library library = new Library();
            var book = new Book();

            book.Title = "The C Programming Language";
            book.Authors = new string[] { "D. Ritchie", "B. Kernighan" };
            book.PublicationDate = "1978";
            book.Edition = "1st";
            book.Genre = "Computers";

            library.Books.Add(book);
            library.DisplayBooks();

            Console.ReadKey();
        }

        public static void DisplayLogin()
        {
            // This function displays the login screen
            Console.WriteLine("Welcome to the Digital Library");
            Console.WriteLine("You are on the login page.");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
        }

    }
}
