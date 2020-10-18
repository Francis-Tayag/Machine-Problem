using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Group2_MachineProblem
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }
    }

    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }
    }

    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }
    }

    public partial class GuestMenuForm : Form
    {
        public GuestMenuForm()
        {
            InitializeComponent();
        }
    }

    public partial class ReaderMenuForm : Form
    {
        private string uname = "Unknown User";
        public ReaderMenuForm(string uname)
        {
            this.uname = uname;
            InitializeComponent();
        }
    }

    public partial class LibrarianMenuForm : Form
    {
        public LibrarianMenuForm()
        {
            InitializeComponent();
        }
    }

    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }
    }

    public partial class ViewUsersForm : Form
    {
        public ViewUsersForm()
        {
            InitializeComponent();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // TESTING
            var f = new WelcomeForm();
            Application.Run(f);
        }
    }
}
