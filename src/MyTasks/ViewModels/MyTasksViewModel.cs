using System;
using MyTasks.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyTasks.ViewModels
{
    public class MyTasksViewModel : BindableObject
    {
        private ObservableCollection<Models.Task> _tasks;

        public MyTasksViewModel()
        {
            Tasks = new ObservableCollection<Models.Task>();

            LoadData();
        }

        public ObservableCollection<Models.Task> Tasks
        {
            get { return _tasks; }
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }

        public ICommand ItemSelectedCommand => new Command<string>(ItemSelected);

        private void LoadData()
        {
            var tasks = TaskService.Instance.GetTasks();

            Tasks.Clear();
            foreach (var task in tasks)
            {
                Tasks.Add(task);
            }
        }

        private void ItemSelected(string parameter)
        {
            var tasks = TaskService.Instance.GetTasks();

            Tasks.Clear();

            // Filter tasks
            foreach (var task in tasks
                .Where(t => t.Status.Equals(parameter, StringComparison.InvariantCultureIgnoreCase)))
            {
                Tasks.Add(task);
            }
        }
    }
}