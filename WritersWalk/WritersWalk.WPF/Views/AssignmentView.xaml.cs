using System.Collections.ObjectModel;
using System.Windows;
using WritersWalk.Application.Models;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Views;

/// <summary>
/// Interaction logic for AssignmentView.xaml
/// </summary>
public partial class AssignmentView : Window
{
    public AssignmentView(int assignmentId, string userId)
    {
        InitializeComponent();
        DataContext = new AssignmentViewModel(assignmentId, userId);
    }
    public AssignmentView(Topic topic, ObservableCollection<Surrounding> selectedSurroundings)
    {
        InitializeComponent();
        DataContext = new AssignmentViewModel(topic, selectedSurroundings);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        ReflectionView reflection = new ReflectionView();
        reflection.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        reflection.Show();
        Close();
    }
}
