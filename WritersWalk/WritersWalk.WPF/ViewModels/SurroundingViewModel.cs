using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Models;
using WritersWalk.WPF.Commands;

namespace WritersWalk.WPF.ViewModels;

public class SurroundingViewModel : BaseViewModel
{
    private readonly SurroundingController _surroundingController;

    private ObservableCollection<Surrounding> surroundings;
    public ObservableCollection<Surrounding> Surroundings
    {
        get { return surroundings; }
        set
        {
            surroundings = value;
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
    private string _newSurroundingTitle;
    public string NewSurroundingTitle
    {
        get { return _newSurroundingTitle; }
        set
        {
            _newSurroundingTitle = value;
            OnPropertyChanged(nameof(NewSurroundingTitle));
        }
    }
    private string _selectedSurroundingsText;
    public string SelectedSurroundingsText
    {
        get { return _selectedSurroundingsText; }
        set
        {
            _selectedSurroundingsText = value;
            OnPropertyChanged(nameof(SelectedSurroundingsText));
        }
    }
    // constructor for the surroundingView that a user interacts with
    public SurroundingViewModel(Topic topic)
    {
        _surroundingController = ServiceLocator.Resolve<SurroundingController>();
        SelectedTopic = topic;
        LoadSurroundings();

    }

    // constructor that the admin interacts with
    public SurroundingViewModel()
    {
        _surroundingController = ServiceLocator.Resolve<SurroundingController>();
        LoadSurroundings();

        // Creates a new assignment if the NewSurroundingTitle is not empty
        CreateNewSurroundingCommand = new RelayCommand(
            async x => await CreateNewSurroundingAsync(),
            x => !string.IsNullOrEmpty(NewSurroundingTitle));

        // Deletes a selected surrounding if the user has selected a surrounding
        DeleteSelectedSurroundngCommand = new RelayCommand(
            async x => await DeleteSelectedSurroundingAsync(),
            x => IsSurroundingSelected = true);
    }

    // finds all the surroundings in the database
    private void LoadSurroundings()
    {
        Surroundings = new ObservableCollection<Surrounding>(_surroundingController.GetAllAsync().Result);
    }

    /// <summary>
    /// Takes a surrounding and adds it to the list SelectedSurroundings
    /// then it takes all selectedsurroundings titles and displays it as a text joining them together but dividing with a comma
    /// </summary>
    /// <param name="selectedSurrounding"> users selected surrounding</param>
    public void HandleSelectedSurroundings(Surrounding selectedSurrounding)
    {
        SelectedSurroundings.Add(selectedSurrounding);
        SelectedSurroundingsText = string.Join(", ", SelectedSurroundings.Select(s => s.Title));
    }

    /// <summary>
    /// Takes a surrounding and stores it as the currently selected surrounding
    /// Sets IsSurroundingSelected to true
    /// </summary>
    /// <param name="selectedSurrounding">users selected surrounding</param>
    public void HandleSelectedSurrounding(Surrounding selectedSurrounding)
    {
        SelectedSurrounding = selectedSurrounding;
        IsSurroundingSelected = true;
    }

    public RelayCommand CreateNewSurroundingCommand { get; }

    /// <summary>
    /// creates a new surrounding by taking a title and using the controller creates a new Surrounding.
    /// then adds it to the list of surroundings
    /// lastly clears the textbox called NewSurroundingTitle so the box is ready for next title.
    /// </summary>
    /// <returns> new Surrounding to list</returns>
    public async Task CreateNewSurroundingAsync()
    {
        if (!string.IsNullOrEmpty(NewSurroundingTitle))
        {
            var newSurrounding = await _surroundingController.CreateAsync(NewSurroundingTitle);
            Surroundings.Add(newSurrounding);
            NewSurroundingTitle = string.Empty;
        }
    }
    public RelayCommand DeleteSelectedSurroundngCommand { get; }
    /// <summary>
    /// If there is a SelectedSurrounding it gets deleted
    /// then remove it from the list so its no longer visible.
    /// </summary>
    /// <returns></returns>
    public async Task DeleteSelectedSurroundingAsync()
    {
        if (IsSurroundingSelected && SelectedSurrounding != null)
        {
            await _surroundingController.DeleteAsync(SelectedSurrounding.Id);
            Surroundings.Remove(SelectedSurrounding);
        }
    }
}

