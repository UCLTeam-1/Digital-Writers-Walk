using System.ComponentModel;
using System.Runtime.CompilerServices;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Models;

namespace WritersWalk.WPF.ViewModels;

public class AdminViewModel : BaseViewModel
{
    private readonly TopicController _topicController;
    private readonly SurroundingController _surroundingController;
    private readonly AssignmentController _assignmentController;


    public AdminViewModel()
    {
        _topicController = ServiceLocator.Resolve<TopicController>();
        _surroundingController = ServiceLocator.Resolve<SurroundingController>();
        _assignmentController = ServiceLocator.Resolve<AssignmentController>();

        Topics = _topicController.GetAllAsync().Result;
        Assignments = _assignmentController.GetAllAsync().Result;
        Surroundings = _surroundingController.GetAllAsync().Result;

    }

    private List<Topic> _topics;
    public List<Topic> Topics
    {
        get { return _topics; }
        set
        {
            _topics = value;
            OnPropertyChanged(nameof(Topics));
        }
    }
    private List<Surrounding> _surroundings;
    public List<Surrounding> Surroundings
    {
        get { return _surroundings; }
        set
        {
            _surroundings = value;
            OnPropertyChanged(nameof(Surroundings));
        }
    }
    private List<Assignment> _assignments;
    public List<Assignment> Assignments
    {
        get { return _assignments; }
        set
        {
            _assignments = value;
            OnPropertyChanged(nameof(Assignments));
        }
    }
    private List<string> _dataList;
    public List<string> DataList
    {
        get { return _dataList; }
        set
        {
            _dataList = value;
            OnPropertyChanged(nameof(DataList));
        }
    }
}
