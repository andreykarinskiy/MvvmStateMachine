using System.Windows;

namespace Shell.Views
{
    using Microsoft.Practices.Unity;

    using Shell.ViewModels;

    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();

            this.Loaded += (sender, args) => this.DataContext = this.ViewModel;
        }

        [Dependency]
        public ShellViewModelViewModel ViewModel { get; set; }
    }
}
