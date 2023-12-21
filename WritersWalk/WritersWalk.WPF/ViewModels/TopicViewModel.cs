using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WritersWalk.Application.Controllers;
using WritersWalk.Application.Models;
using WritersWalk.WPF.Commands;

namespace WritersWalk.WPF.ViewModels;

public class TopicViewModel : BaseViewModel
{
    /// <summary>
    /// get all logic from Application layerTopic, TopicController
    /// </summary>
    private readonly TopicController _topicController;

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
    /// <summary>
    /// creates a new list with selected Topics
    /// </summary>
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
    private string _newTopicTitle;
    public string NewTopicTitle
    {
        get { return _newTopicTitle; }
        set
        {
            _newTopicTitle = value;
            OnPropertyChanged(nameof(NewTopicTitle));
        }
    }

    public TopicViewModel()
    {
        _topicController = ServiceLocator.Resolve<TopicController>();
        LoadTopics();

        // creates a topic if NewTopicTitle is not empty
        CreateNewTopicCommand = new RelayCommand(
            async x => await CreateNewTopicAsync(),
            x => !string.IsNullOrEmpty(NewTopicTitle));
        // Deletes a topic if there is a topic selected
        DeleteSelectedTopicCommand = new RelayCommand(
            async x => await DeleteSelectedTopicAsync(),
            x => IsTopicSelected = true);
    }

    /// <summary>
    /// Loads all Topics from the topicController
    /// </summary>
    private void LoadTopics()
    {
        Topics = new ObservableCollection<Topic>(_topicController.GetAllAsync().Result);
    }

    /// <summary>
    /// Sets the SelectedTopic when it is clicked and marks IsTopicSelected as "True"
    /// </summary>
    /// <param name="selectedTopic"></param>
    public void HandleSelectedTopic(Topic selectedTopic)
    {
        SelectedTopic = selectedTopic;

        IsTopicSelected = true;
    }

    public RelayCommand CreateNewTopicCommand { get; }

    /// <summary>
    /// if string is not empty, create a new topic.
    /// add that topic to the list
    /// clear the textbox NewTopicTitle for next action
    /// </summary>
    /// <returns>new topic</returns>
    public async Task CreateNewTopicAsync()
    {
        if (!string.IsNullOrEmpty(NewTopicTitle))
        {
            var newTopic = await _topicController.CreateTopicAsync(NewTopicTitle);
            Topics.Add(newTopic);
            NewTopicTitle = string.Empty;
        }
    }
    public RelayCommand DeleteSelectedTopicCommand { get; }
    /// <summary>
    /// if there is a topic selected, it deletes that topic
    /// then it removes that topic from the list
    /// </summary>
    /// <returns></returns>
    public async Task DeleteSelectedTopicAsync()
    {
        if (IsTopicSelected && SelectedTopic != null)
        {
            await _topicController.DeleteTopicAsync(SelectedTopic.Id);
            Topics.Remove(SelectedTopic);

        }
    }
}
