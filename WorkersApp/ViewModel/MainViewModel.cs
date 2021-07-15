using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WorkersApp.Command;
using System.Windows.Media;
using System.Windows;

namespace WorkersApp.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Model.MainModel context = new Model.MainModel();
        private Brush _backColor;
        private Brush _textColor;
        private List<Model.WorkersTasksView> _workers;
        private List<Model.Tasks> _tasks;
        private Model.WorkersTasksView _selectedRow;
        private string _identyfikatorText;
        private string _daneText;
        

        public MainViewModel()
        {
            WindowLoad = new RelayCommand(Window_Loaded);
            AddNewWorker = new RelayCommand(Add_New_Worker);
            DeleteWorker = new RelayCommand(Delete_Worker);
        }

        private void Window_Loaded(object obj)
        {
            BackColor = Brushes.CornflowerBlue;
            TextColor = Brushes.White;

            WorkersList = context.WorkersTasksView.ToList();
        }
        private void UpdateTasks(object obj)
        {
            IdentyfikatorText = "Identyfikator: " + SelectedRow.ID.ToString();
            DaneText = "Dane: " + SelectedRow.FirstName.ToString() + " " + SelectedRow.LastName.ToString();
            var querry = context.Tasks.Where(x => x.WorkerID == SelectedRow.ID).ToList();
            TasksList = querry;
        }
        private void Add_New_Worker(object obj)
        {
            var dialog = new CustomWindow();
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                Model.Workers worker = new Model.Workers();
                worker.FirstName = dialog.CustomWindowResultFirstName;
                worker.LastName = dialog.CustomWindowResultLastName;
                context.Workers.Add(worker);
                context.SaveChanges();
                WorkersList = context.WorkersTasksView.ToList();
            }
        }
        private void Delete_Worker(object obj)
        {
            var deleteRecord = context.Workers.Where(x => x.ID == SelectedRow.ID).First();
            context.Workers.Remove(deleteRecord);
            context.SaveChanges();
            WorkersList = context.WorkersTasksView.ToList();
        }

        public Brush BackColor
        {
            get => _backColor;
            set
            {
                _backColor = value;
                OnPropertyChanged();
            }
        }
        public Brush TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                OnPropertyChanged();
            }
        }
        public List<Model.WorkersTasksView> WorkersList
        {
            get => _workers;
            set
            {
                _workers = value;
                OnPropertyChanged();
            }
        }
        public List<Model.Tasks> TasksList
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged();
            }
        }
        public Model.WorkersTasksView SelectedRow
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
                if(_selectedRow != null) UpdateTasks(value);
                OnPropertyChanged();
            }
        }
        public string IdentyfikatorText
        {
            get => _identyfikatorText;
            set
            {
                _identyfikatorText = value;
                OnPropertyChanged();
            }
        }
        public string DaneText
        {
            get => _daneText;
            set
            {
                _daneText = value;
                OnPropertyChanged();
            }
        }
        public ICommand WindowLoad { get; set; }
        public ICommand AddNewWorker { get; set; }
        public ICommand DeleteWorker { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class WorkerClass
        {
            public string imie { get; set; }
            public string nazwisko { get; set; }
        }
    }
}
