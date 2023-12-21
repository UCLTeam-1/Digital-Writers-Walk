using System.Windows.Controls;
using WritersWalk.Application.Models;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Pages;

public partial class SurroundingPage : Page
{
    private SurroundingViewModel _viewModel;

    public SurroundingPage()
    {
        InitializeComponent();
        _viewModel = new SurroundingViewModel();
        DataContext = _viewModel;
    }
    private void DisplaySurroundings_HandleSelectedSurrounding(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListBox listBox && listBox.SelectedItem is Surrounding selectedSurrounding)
        {
            _viewModel.HandleSelectedSurrounding(selectedSurrounding);
        }
    }
}
