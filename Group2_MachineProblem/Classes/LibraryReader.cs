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
        private string booksBorrowed;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BooksBorrowed { get; set; }
    }
}
