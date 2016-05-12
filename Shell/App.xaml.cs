using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ShellBootstrapper bootstrapper;

        public App()
        {
            this.bootstrapper = new ShellBootstrapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            this.bootstrapper.Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            this.bootstrapper.Dispose();

            base.OnExit(e);
        }
    }
}
