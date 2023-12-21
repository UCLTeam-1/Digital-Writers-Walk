using System.Collections.ObjectModel;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Models;
using WritersWalk.WPF.Commands;

namespace WritersWalk.WPF.ViewModels;
internal class AssignmentViewModel : BaseViewModel
{
    private Assignment _assignment;
    private List<int> _surroundingsId;
    private DispatcherTimer _timer;
    private TimeSpan _countdownTime;
    private string _countdownTimeText;
    private readonly AssignmentController _assignmentController;

    private AssignmentUser _assignmentUser;

    private SoundPlayer _soundPlayer;
    public Assignment Assignment
    {
        get { return _assignment; }
        set
        {
            if (_assignment != value)
            {
                _assignment = value;
                OnPropertyChanged();
            }
        }
    }

    public string CountdownTimeText
    {
        get { return _countdownTimeText; }
        set
        {
            if (_countdownTimeText != value)
            {
                _countdownTimeText = value;
                OnPropertyChanged();
            }
        }
    }

    public RelayCommand AddTwoMinutesCommand { get; private set; }
    public RelayCommand FinishAssignmentCommand { get; private set; }
    public Topic Topic { get; }
    public ObservableCollection<Surrounding> SelectedSurroundings { get; }

    /// <summary>
    /// Initializes a new instance of the AssignmentViewModel class with the specified assignment ID and user ID.
    /// </summary>
    /// <param name="assignmentId">The ID of the assignment</param>
    /// <param name="userId">The ID of the user</param>
    public AssignmentViewModel(int assignmentId, string userId)
    {
        _assignmentController = ServiceLocator.Resolve<AssignmentController>();
        Assignment = _assignmentController.GetAssignmentInProgress(userId).Result;
        _assignmentUser = _assignmentController.GetAssignmentUserByIdAsync(assignmentId, userId).Result;
        StartTimer();

        AddTwoMinutesCommand = new RelayCommand(_ => AddTwoMinutes());
        FinishAssignmentCommand = new RelayCommand(_ => FinishAssignment());
    }

    /// <summary>
    /// Initializes a new instance of the AssignmentViewModel class with the specified topic and selected surroundings.
    /// </summary>
    /// <param name="topic">The topic of the assignment</param>
    /// <param name="selectedSurroundings">The collection of selected surroundings</param>
    public AssignmentViewModel(Topic topic, ObservableCollection<Surrounding> selectedSurroundings)
    {
        _surroundingsId = selectedSurroundings.Select(s => s.Id).ToList();
        Topic = topic;
        SelectedSurroundings = selectedSurroundings;

        _assignmentController = ServiceLocator.Resolve<AssignmentController>();
        LoadNewAssignment().Wait();
        StartTimer();

        AddTwoMinutesCommand = new(_ => AddTwoMinutes());
        FinishAssignmentCommand = new RelayCommand(_ => FinishAssignment());
    }

    /// <summary>
    /// Starts the countdown timer for the assignment.
    /// </summary>
    private void StartTimer()
    {
        _countdownTime = TimeSpan.FromMinutes(10);

        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    /// <summary>
    /// Loads a new assignment based on the specified topic and selected surroundings.
    /// </summary>
    /// <returns>A task representing the async operation</returns>
    private async Task LoadNewAssignment()
    {
        Assignment = await _assignmentController.GetAssignmentAsync(Topic.Id, _surroundingsId, "1");
        if (Assignment == null)
        {
            Assignment = await _assignmentController.GetRandomAssignmentAsync();
        }

        // check assignmentUser exists   
        var assignmentUser = await _assignmentController.GetAssignmentUserByIdAsync(Assignment.Id, "1");

        if (assignmentUser != null)
        {
            _assignmentUser = assignmentUser;
        }
        else
        {
            _assignmentUser = new AssignmentUser
            {
                AssignmentId = Assignment.Id,
                UserId = "1",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddMinutes(10),
                Status = AssignmentStatus.InProgress
            };
            _assignmentController.CreateAssignmentUser(_assignmentUser);
        }
    }

    /// <summary>
    /// Event handler for the countdown timer tick event.
    /// </summary>
    private void Timer_Tick(object sender, EventArgs e)
    {
        _countdownTime = _countdownTime.Subtract(TimeSpan.FromSeconds(1));

        if (_countdownTime <= TimeSpan.Zero)
        {
            _timer.Stop();
            MessageBox.Show("Countdown is finished!");
        }
        else if (_countdownTime == TimeSpan.FromMinutes(1))
        {
            using (Stream soundFileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("WritersWalk.WPF.Assets.rooster.wav"))
            {
                _soundPlayer = new SoundPlayer(soundFileStream);
                _soundPlayer.Play();
            }
        }

        CountdownTimeText = _countdownTime.ToString(@"mm\:ss");
    }

    /// <summary>
    /// Adds two minutes to the countdown timer and updates the assignment user's end time.
    /// </summary>
    private void AddTwoMinutes()
    {
        _countdownTime = _countdownTime.Add(TimeSpan.FromMinutes(2));
        CountdownTimeText = _countdownTime.ToString(@"mm\:ss");

        _assignmentUser.EndTime = _assignmentUser.EndTime.Value.AddMinutes(2);
        _assignmentController.UpdateAssignmentUser(_assignmentUser);
    }

    /// <summary>
    /// Marks the assignment as completed.
    /// </summary>
    private void FinishAssignment()
    {
        _assignmentUser.Status = AssignmentStatus.Completed;
        _assignmentController.UpdateAssignmentUser(_assignmentUser);
    }

}

