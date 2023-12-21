
using System.Windows;
using System.Windows.Controls;
using WritersWalk.Application.Models;
using WritersWalk.WPF.ViewModels;
using WritersWalk.WPF.Views;


namespace WritersWalk.WPF;


public partial class TopicView : Window
{

    private TopicViewModel _viewModel;
    public TopicView()
    {
        InitializeComponent();
        _viewModel = new TopicViewModel();
        DataContext = _viewModel;
    }
    private void DisplayTopics_HandleSelectedTopic(object sender, SelectionChangedEventArgs e)
    {
        if (sender is ListBox listBox && listBox.SelectedItem is Topic selectedTopic)
        {
            _viewModel.HandleSelectedTopic(selectedTopic);
        }
    }

    // Displays SurroundingView and closes CurrentView if a Topic is chosen
    private void GoToSurroundingView_Click(object sender, RoutedEventArgs e)
    {
        if (_viewModel.IsTopicSelected)
        {
            SurroundingView surroundingView = new SurroundingView(_viewModel.SelectedTopic);
            surroundingView.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            surroundingView.Show();
            Close();
        }
        else
        {
            MessageBox.Show("Please select a topic before proceeding.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
