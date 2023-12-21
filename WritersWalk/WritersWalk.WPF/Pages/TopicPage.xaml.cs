using System.Windows;
using System.Windows.Controls;
using WritersWalk.Application.Models;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Pages;

/// <summary>
/// Interaction logic for TopicPage.xaml
/// </summary>
public partial class TopicPage : Page
{
    private TopicViewModel _viewModel;

    public TopicPage()
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

    private async void SaveNewTopic_Click(object sender, RoutedEventArgs e)
    {
        await _viewModel.CreateNewTopicAsync();
        NewTopicTitle.Text = "";
    }
}
