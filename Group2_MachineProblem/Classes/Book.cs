using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2_MachineProblem
{
    class Book
    {
        // Fields
        private string id, title, datePub, edition, genre;
        private string[] authors;

        // Accessors
        public string Id { get; set; }
        public string Title { get; set; }
        public string DatePub { get; set; }
        public string Edition { get; set; }
        public string Genre { get; set; }
        public string[] Authors { get; set; }

    }
}
