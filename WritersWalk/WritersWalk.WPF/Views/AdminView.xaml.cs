using System.Windows;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Views;

/// <summary>
/// Interaction logic for AdminView.xaml
/// </summary>
public partial class AdminView : Window
{
    private AdminViewModel adminViewModel;
    public AdminView()
    {
        InitializeComponent();
        AdminViewModel adminViewModel = new AdminViewModel();
        DataContext = adminViewModel;
    }

    private void TopicButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigate to the TopicPage
        mainFrame.Navigate(new Pages.TopicPage());
    }

    private void SurroundingButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigate to the SurroundingPage
        mainFrame.Navigate(new Pages.SurroundingPage());
    }

    private void AssignmentButton_Click(object sender, RoutedEventArgs e)
    {
        // Navigate to the AssignmentPage
        mainFrame.Navigate(new Pages.AssignmentPage());
    }
    private void GoToMainView(object sender, RoutedEventArgs e)
    {
        MainWindow main = new MainWindow();
        main.Show();
        Close();
    }
}
