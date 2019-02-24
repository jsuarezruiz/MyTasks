using MyTasks.ViewModels;
using Xamarin.Forms;

namespace MyTasks.Views
{
    public partial class MyTasksView : ContentPage
    {
        public MyTasksView()
        {
            InitializeComponent();

            BindingContext = new MyTasksViewModel();
        }
    }
}
