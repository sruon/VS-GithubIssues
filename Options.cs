using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace sruon.GithubIssues
{
    //http://msdn.microsoft.com/en-us/library/vstudio/bb166195.aspx
    public class Options : DialogPage
    {
        private string username;
        private string password;
        private string user;
        private string repo;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Repo
        {
            get { return repo; }
            set { repo = value; }
        }
    }
}
