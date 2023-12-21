using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WritersWalk.Application.Controllers;
using WritersWalk.WPF.Views;

namespace WritersWalk.WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TopicController _topicController;
    private AssignmentController _assignmentController;

    public List<string> MyList { get; set; }

    public MainWindow()
    {
        InitializeComponent();
        _topicController = ServiceLocator.Resolve<TopicController>();
        _assignmentController = ServiceLocator.Resolve<AssignmentController>();
        DataContext = this;
    }

    private void postData_Click(object sender, RoutedEventArgs e)
    {
        var assignmentInProgress = _assignmentController.GetAssignmentInProgress("1").Result;
        if (assignmentInProgress != null)
        {
            AssignmentView assignment = new AssignmentView(assignmentInProgress.Id, "1");
            assignment.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            assignment.Show();
            Close();
        }
        else
        {
            //open topic window
            TopicView topic = new TopicView();
            topic.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            topic.Show();
            Close();
        }
    }
    private void GoToAdminView(object sender, RoutedEventArgs e)
    {
        AdminView admin = new AdminView();
        admin.Show();
        Close();
    }
}



public static class ServiceLocator
{
    public static T Resolve<T>()
    {
        var app = System.Windows.Application.Current as App;
        if (app != null && app.AppHost != null)
        {
            return app.AppHost.Services.GetRequiredService<T>();
        }
        else
        {
            // Handle the error case here, maybe throw an exception or return default
            throw new Exception("App or AppHost was null!");
        }
    }
}
