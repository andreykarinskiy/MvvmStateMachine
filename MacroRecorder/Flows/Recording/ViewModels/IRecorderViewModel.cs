namespace MacroRecorder.Flows.Recording.ViewModels
{
    using System.Windows.Input;

    public interface IRecorderViewModel
    {
        string Status { get; }
        
        ICommand Start { get; }
        
        bool CanStart { get; }
        
        ICommand Pause { get; }
        
        bool CanPause { get; }
        
        ICommand Stop { get; }
        
        bool CanStop { get; } 
    }
}
