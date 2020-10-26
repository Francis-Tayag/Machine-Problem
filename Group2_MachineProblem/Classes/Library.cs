// TODO
// About the constructor...might be a good idea to have a conditional
// So that it does not load everything

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    class Library
    {
        private List<LibraryUser> usersList;
        private List<Book> booksList;
        private List<string> borrowings;

        public List<LibraryUser> UsersList
        {
            get { return usersList; }
        }

        public List<Book> BooksList
        {
            get { return booksList; }
        }

        public List<string> Borrowings
        {
            get { return borrowings; }
        }

        public Library()
        {
            // load the users from Users.txt
            LoadUsers("Users.txt");

            // load the books from Books.txt
            LoadBooks("Books.txt");

            // load the borrowed books from Borrowings.txt
            LoadBorrowings("Borrowings.txt");
        }

        private void LoadBorrowings(string filepath)
        {
            if (!File.Exists(filepath))
            {
                MessageBox.Show("File {0} does not exist.", filepath);
            }
            else
            {
                string[] lines;
                borrowings = new List<string>();
                int fileLength = File.ReadAllLines(filepath).Length; // gets the number of lines in the program
                lines = ReadFromFile(filepath);

                for (int i = 0; i < fileLength; i++)
                {
                    string[] infoList = lines[i].Split(';');
                    string toAdd = string.Format("{0};{1};", infoList[0], infoList[1]);
                    borrowings.Add(toAdd);
                }
            }
        }

        private void LoadBooks(string filepath)
        {
            // TODO
            if(!File.Exists(filepath))
            {
                MessageBox.Show("File {0} does not exist.", filepath);
            }
            else
            {
                string[] lines;
                booksList = new List<Book>();
                int fileLength = File.ReadAllLines(filepath).Length; // gets the number of lines in the program
                lines = ReadFromFile(filepath);

                for (int i = 0; i < fileLength; i++)
                {
                    string[] infoList = lines[i].Split(';');
                    string[] authors = infoList[4].Split('|'); // get the list of authors

                    // instantiate and set fields of Book class
                    var book = new Book();
                    book.Title = infoList[0];
                    book.DatePub = infoList[1];
                    book.Edition = infoList[2];
                    book.Genre = infoList[3];
                    book.Authors = string.Join(",", authors).TrimEnd(',');

                    // add the book class into the books list
                    booksList.Add(book);
                }
            }
        }
        
        private void LoadUsers(string filepath)
        {
            // this function loads the users from a filepath (Users.Txt)
            if (!File.Exists(filepath))
            {
                MessageBox.Show("File {0} does not exist.", filepath);
            }
            else
            {
                string[] lines;
                usersList = new List<LibraryUser>();
                int fileLength = File.ReadAllLines(filepath).Length; // gets the number of lines in the program
                lines = ReadFromFile(filepath);

                for (int i = 0; i < fileLength; i++)
                {
                    string[] infoList = lines[i].Split(';');
                    string[] borrowedBooks = infoList[4].Split('|'); // get the list of borrowed books

                    // instantiate set fields of LibraryReader class
                    var user = new LibraryReader();
                    user.UserName = infoList[0];
                    user.FirstName = infoList[1];
                    user.LastName = infoList[2];
                    user.Pin = infoList[3];
                    user.BooksBorrowed = string.Join(",", borrowedBooks).TrimEnd(',');

                    // add the user class into the users list
                    usersList.Add(user);
                }
            }
        }

        public void SaveBorrowings()
        {
            if(borrowings.Count == 0)
            {
                try
                {
                    File.WriteAllText("Borrowings.txt", string.Empty);
                }
                catch (Exception error)
                {
                    Console.Write(error);
                }
            }
            else
            {
                foreach (string line in borrowings)
                {
                    try
                    {
                        using (StreamWriter w = new StreamWriter("Borrowings.txt", false))
                        {
                            w.WriteLine(line);
                        }
                    }
                    catch (Exception error)
                    {
                        Console.Write(error);
                    }

                }
            }
            
            
        }

        private static string[] ReadFromFile(string filepath)
        {
            // generic function that reads content from file
            string[] lines;

            try
            {
                lines = System.IO.File.ReadAllLines(@filepath);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Program experienced an error during runtime: ", e);
            }
            return lines;
        }
    }
}
