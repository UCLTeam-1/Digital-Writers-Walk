using System.Windows.Controls;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Pages;


public partial class AssignmentPage : Page
{
    private AssignmentPageViewModel _viewModel;
    public AssignmentPage()
    {
        InitializeComponent();
        _viewModel = new AssignmentPageViewModel();
        DataContext = _viewModel;

    }
}
