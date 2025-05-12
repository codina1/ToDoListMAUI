using System.Collections.ObjectModel;
using System.Windows.Input;
using TodoMaui.Models;
using TodoMaui.Services;

namespace TodoMaui.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private readonly SQLiteService _sqliteService;
        private ObservableCollection<TaskItem>? _tasks;
        private string? _newTaskTitle;

        public ObservableCollection<TaskItem> Tasks
        {
            get => _tasks ?? new ObservableCollection<TaskItem>();
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public string NewTaskTitle
        {
            get => _newTaskTitle ?? string.Empty;
            set
            {
                _newTaskTitle = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddTaskCommand { get; }
        public ICommand DeleteTaskCommand { get; }
        public ICommand ToggleTaskCommand { get; }

        public MainViewModel()
        {
            _sqliteService = new SQLiteService();
            Tasks = new ObservableCollection<TaskItem>();
            AddTaskCommand = new Command(AddTask);
            DeleteTaskCommand = new Command<TaskItem>(DeleteTask);
            ToggleTaskCommand = new Command<TaskItem>(ToggleTask);
            LoadTasks();
        }

        private async void LoadTasks()
        {
            var tasks = await _sqliteService.GetTasksAsync();
            Tasks.Clear();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        private async void AddTask()
        {
            if (string.IsNullOrWhiteSpace(NewTaskTitle))
                return;

            var task = new TaskItem
            {
                Title = NewTaskTitle,
                IsCompleted = false,
                CreatedAt = DateTime.Now
            };

            await _sqliteService.SaveTaskAsync(task);
            Tasks.Add(task);
            NewTaskTitle = string.Empty;
        }

        private async void DeleteTask(TaskItem task)
        {
            await _sqliteService.DeleteTaskAsync(task);
            Tasks.Remove(task);
        }

        private async void ToggleTask(TaskItem task)
        {
            task.IsCompleted = !task.IsCompleted;
            await _sqliteService.SaveTaskAsync(task);
        }
    }
} 