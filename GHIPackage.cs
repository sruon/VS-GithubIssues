using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using System.Windows.Forms;

namespace sruon.GithubIssues
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(Window))]
    [ProvideOptionPage(typeof(Options), "Github Issues", "General", 101, 106, true)]
    [Guid(GuidList.guidVSPackage1PkgString)]
    public sealed class GHIPackage : Package
    {
        public GHIPackage()
        {
        }

        private Window _window;
        
        private void ShowToolWindow(object sender, EventArgs e)
        {
            
            ToolWindowPane window = this.FindToolWindow(typeof(Window), 0, true);
            _window = window as Window;
            _window.GHOptions = optionsPage;
            if ((null == window) || (null == window.Frame))
            {
                throw new NotSupportedException(Resources.CanNotCreateWindow);
            }
            IVsWindowFrame windowFrame = (IVsWindowFrame)window.Frame;
            Microsoft.VisualStudio.ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }


        /////////////////////////////////////////////////////////////////////////////
        // Overridden Package Implementation
        #region Package Members

        private Options optionsPage = null;

        protected override void Initialize()
        {
            base.Initialize();
            optionsPage = GetDialogPage(typeof(Options)) as Options; 
            OleMenuCommandService mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if ( null != mcs )
            {
                CommandID toolwndCommandID = new CommandID(GuidList.guidVSPackage1CmdSet, (int)PkgCmdIDList.cmdidMyTool);
                MenuCommand menuToolWin = new MenuCommand(ShowToolWindow, toolwndCommandID);
                mcs.AddCommand( menuToolWin );
            }
            _window = this.FindToolWindow(typeof(Window), 0, true) as Window;
            _window.GHOptions = optionsPage;
        }
        #endregion

    }
}
