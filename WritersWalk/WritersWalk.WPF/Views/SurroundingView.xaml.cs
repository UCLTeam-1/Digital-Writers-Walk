using System.Windows;
using System.Windows.Controls;
using WritersWalk.Application.Models;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Views;

public partial class SurroundingView : Window
{
    private SurroundingViewModel _viewModel;
    public SurroundingView(Topic topic)
    {
        InitializeComponent();

        _viewModel = new SurroundingViewModel(topic);
        DataContext = _viewModel;
    }

    private void DisplaySurrounding_HandleSelectedSurroundings(object sender, SelectionChangedEventArgs e)
    {
        if (_viewModel != null)
        {
            _viewModel.SelectedSurroundings.Clear();

            foreach (var selectedItem in DisplaySurrounding.SelectedItems)
            {
                if (selectedItem is Surrounding selectedSurrounding)
                {
                    _viewModel.HandleSelectedSurroundings(selectedSurrounding);
                }
            }
        }
    }

    private void getAssignment_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel.SelectedSurroundings.Any())
        {
            AssignmentView assignment = new AssignmentView(_viewModel.SelectedTopic, _viewModel.SelectedSurroundings);
            assignment.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            assignment.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Please select a surrounding before proceeding.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
