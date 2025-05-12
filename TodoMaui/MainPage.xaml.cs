namespace TodoMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox checkBox && checkBox.BindingContext is TodoMaui.Models.TaskItem task)
            {
                if (BindingContext is TodoMaui.ViewModels.MainViewModel vm)
                {
                    vm.ToggleTaskCommand.Execute(task);
                }
            }
        }
    }
}
