using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2_MachineProblem
{
    class LibraryReader : LibraryUser
    {
        private string firstName, lastName;
        private Book[] booksBorrowed;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Book[] BooksBorrowed { get; set; }
    }
}
