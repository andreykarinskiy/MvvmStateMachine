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

namespace MacroRecorder.Flows.Saving.Views
{
    using MacroRecorder.Flows.Saving.ViewModels;

    /// <summary>
    /// Логика взаимодействия для SavingMacroView.xaml
    /// </summary>
    public partial class SavingMacroView : UserControl
    {
        public SavingMacroView(SavingMacroViewModel viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
