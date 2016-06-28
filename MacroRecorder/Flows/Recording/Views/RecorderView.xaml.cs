namespace MacroRecorder.Flows.Recording.Views
{
    using System.Windows.Controls;

    using MacroRecorder.Flows.Recording.ViewModels;

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
