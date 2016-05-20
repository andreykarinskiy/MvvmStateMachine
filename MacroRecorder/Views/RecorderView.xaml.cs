using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MacroRecorder.Views
{
    using MacroRecorder.ViewModels;

    using Microsoft.Practices.Unity;

    /// <summary>
    /// Логика взаимодействия для RecorderView.xaml
    /// </summary>
    public partial class RecorderView : UserControl
    {
        public RecorderView(RecorderViewModel viewModel) : this()
        {
            this.DataContext = viewModel;
        }

        public RecorderView()
        {
            InitializeComponent();
        }
    }
}
