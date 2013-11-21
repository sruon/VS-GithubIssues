using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Shell;

namespace sruon.GithubIssues
{
    [Guid("53a4dafb-3976-4b6d-95c3-5533d0bee201")]
    public class Window : ToolWindowPane
    {
        private Options options;

        public Options GHOptions
        {
            get { return options; }
            set { options = value; }
        }
        /// <summary>
        /// Standard constructor for the tool window.
        /// </summary>
        public Window() :
            base(null)
        {
            this.Caption = Resources.ToolWindowTitle;
            this.BitmapResourceID = 301;
            this.BitmapIndex = 1;
            base.Content = new Controls(this);
        }
    }
}
