using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WritersWalk.WPF.ViewModels;

namespace WritersWalk.WPF.Views;

/// <summary>
/// Interaction logic for ReflectionView.xaml
/// </summary>
public partial class ReflectionView : Window
{
    private int rating = 0;
    public ReflectionView()
    {
        InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TopicView topic = new TopicView();
        topic.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        topic.Show();
        Close();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        FinnishView finnish = new FinnishView();
        finnish.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        finnish.Show();
        Close();
    }
    private void star_MouseEnter(object sender, MouseEventArgs e)
    {
        Button button = (Button)sender;
        button.Content = "★";
    }
    private void star_MouseLeave(object sender, MouseEventArgs e)
    {
        Button button = (Button)sender;
        if (Convert.ToInt32(button.Tag) <= rating)
            button.Content = "★";
        else
            button.Content = "☆";
    }

    private void star_Click(object sender, RoutedEventArgs e)
    {
        Button button = (Button)sender;
        if (button.Tag != null)
        {
            rating = Convert.ToInt32(button.Tag);
        }

        RefreshStars();
    }

    private void RefreshStars()
    {
        star1.Content = star1.Tag != null && Convert.ToInt32(star1.Tag) <= rating ? "★" : "☆";
        star2.Content = star2.Tag != null && Convert.ToInt32(star2.Tag) <= rating ? "★" : "☆";
        star3.Content = star3.Tag != null && Convert.ToInt32(star3.Tag) <= rating ? "★" : "☆";
        star4.Content = star4.Tag != null && Convert.ToInt32(star4.Tag) <= rating ? "★" : "☆";
        star5.Content = star5.Tag != null && Convert.ToInt32(star5.Tag) <= rating ? "★" : "☆";
        
        star1.Foreground = star1.Tag != null && Convert.ToInt32(star1.Tag) <= rating ? Brushes.Gold : Brushes.White;
        star2.Foreground = star2.Tag != null && Convert.ToInt32(star2.Tag) <= rating ? Brushes.Gold : Brushes.White;
        star3.Foreground = star3.Tag != null && Convert.ToInt32(star3.Tag) <= rating ? Brushes.Gold : Brushes.White;
        star4.Foreground = star4.Tag != null && Convert.ToInt32(star4.Tag) <= rating ? Brushes.Gold : Brushes.White;
        star5.Foreground = star5.Tag != null && Convert.ToInt32(star5.Tag) <= rating ? Brushes.Gold : Brushes.White;

    }
}
