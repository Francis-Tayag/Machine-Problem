using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2_MachineProblem
{
    class LibraryUser
    {
        private string userName, pin;

        public string UserName
        {
            get { return userName;  }
            set { userName = value; }
        }
        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }
    }
}
