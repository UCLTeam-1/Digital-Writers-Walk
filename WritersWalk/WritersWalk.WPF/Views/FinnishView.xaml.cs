using System.Windows;

namespace WritersWalk.WPF.ViewModels;

/// <summary>
/// Interaction logic for FinnishView.xaml
/// </summary>
public partial class FinnishView : Window
{
    public FinnishView()
    {
        InitializeComponent();
    }

    private void Finish_Click(object sender, RoutedEventArgs e)
    {
        MainWindow main = new MainWindow();
        main.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        main.Show();
        Close();

    }
}
