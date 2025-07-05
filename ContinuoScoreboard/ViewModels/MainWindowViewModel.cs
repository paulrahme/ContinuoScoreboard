namespace ContinuoScoreboard.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public ScoreViewModel ScoreViewModel { get; } = new();
}