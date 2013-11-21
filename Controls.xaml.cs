using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualStudio.Shell;
using EnvDTE;
using Octokit;

namespace sruon.GithubIssues
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class Controls : UserControl
    {
        public Window _parent;

        private Options getOptions()
        {
            return _parent.GHOptions;
        }

        public Controls(Window parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private async void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            Options options = getOptions();
            if (options.Username != null && options.Password != null)
            {
                GitHubClient client = new GitHubClient(new ProductHeaderValue("gh-issues", "1.0"))
                {
                    Credentials = new Credentials(options.Username, options.Password)
                };
            }
            else
            {
                GitHubClient client = new GitHubClient(new ProductHeaderValue("gh-issues", "1.0"));
            }

            var issues = await client.Issue.GetForRepository(options.User, options.Repo);
            issuesTree.Items.Clear();
            foreach (var issue in issues)
                {
                    var item = new TreeViewItem() {Header = issue.Title};
                    issuesTree.Items.Add(item);
                    var subItem = new TreeViewItem() {Header = issue.Body };
                    item.Items.Add(subItem);
                }
        }
    }
}