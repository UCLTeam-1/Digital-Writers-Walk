using System.Collections.ObjectModel;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Models;

namespace WritersWalk.WPF.ViewModels;

internal class AssignmentPageViewModel : BaseViewModel
{
    private readonly AssignmentController _assignmentController;
    private readonly SurroundingController _surroundingController;
    private readonly TopicController _topicController;

    private ObservableCollection<Assignment> _assignments;
    public ObservableCollection<Assignment> Assignments
    {
        get { return _assignments; }
        set
        {
            _assignments = value;
            OnPropertyChanged(nameof(Assignments));
        }
    }

    private Assignment _selectedAssignment;
    public Assignment SelectedAssignment
    {
        get { return _selectedAssignment; }
        set
        {
            _selectedAssignment = value;
            OnPropertyChanged(nameof(SelectedAssignment));
        }
    }

    private bool _isAssignmentSelected;
    public bool IsAssignmentSelected
    {
        get { return _isAssignmentSelected; }
        set
        {
            _isAssignmentSelected = value;
            OnPropertyChanged(nameof(IsAssignmentSelected));
        }
    }


    private ObservableCollection<Surrounding> _surrounding;
    public ObservableCollection<Surrounding> Surroundings
    {
        get { return _surrounding; }
        set
        {
            _surrounding = value;
            OnPropertyChanged(nameof(Surroundings));
        }
    }

    private ObservableCollection<Surrounding> _selectedSurroundings = new ObservableCollection<Surrounding>();
    public ObservableCollection<Surrounding> SelectedSurroundings
    {
        get { return _selectedSurroundings; }
        set
        {
            _selectedSurroundings = value;
            OnPropertyChanged(nameof(SelectedSurroundings));
        }
    }

    private Surrounding _selectedSurrounding;
    public Surrounding SelectedSurrounding
    {
        get { return _selectedSurrounding; }
        set
        {
            _selectedSurrounding = value;
            OnPropertyChanged(nameof(SelectedSurrounding));
        }
    }

    private bool _isSurroundingSelected;
    public bool IsSurroundingSelected
    {
        get { return _isSurroundingSelected; }
        set
        {
            _isSurroundingSelected = value;
            OnPropertyChanged(nameof(IsSurroundingSelected));
        }
    }



    private ObservableCollection<Topic> _topics;
    public ObservableCollection<Topic> Topics
    {
        get { return _topics; }
        set
        {
            _topics = value;
            OnPropertyChanged(nameof(Topics));
        }
    }

    private Topic _selectedTopic;
    public Topic SelectedTopic
    {
        get { return _selectedTopic; }
        set
        {
            _selectedTopic = value;
            OnPropertyChanged(nameof(SelectedTopic));
        }
    }

    private bool _isTopicSelected;
    public bool IsTopicSelected
    {
        get { return _isTopicSelected; }
        set
        {
            _isTopicSelected = value;
            OnPropertyChanged(nameof(IsTopicSelected));
        }
    }


    public AssignmentPageViewModel()
    {
        _assignmentController = ServiceLocator.Resolve<AssignmentController>();
        Load();
    }
    public void Load()
    {
        Assignments = new ObservableCollection<Assignment>(_assignmentController.GetAllAsync().Result);
    }
}
