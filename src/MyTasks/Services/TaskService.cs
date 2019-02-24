using System.Collections.Generic;
using Xamarin.Forms;

namespace MyTasks.Services
{
    public class TaskService
    {
        private static TaskService _instance;

        public static TaskService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TaskService();

                return _instance;
            }
        }

        public List<Models.Task> GetTasks()
        {
            // NOTE: In this sample the focus is on the UI. This is a Fake service.
            return new List<Models.Task>
            {
                new Models.Task { Name = "Customer meeting", Category = "Hangouts", Status = "Warning", Time = "6pm", Color = Color.FromHex("#EEB611"), People = new List<Models.Person> { new Models.Person { Photo = "face2" }, new Models.Person { Photo = "face5" } }, Completed = false },
                new Models.Task { Name = "Catch up with Brian", Category = "Mobile Project", Status = "Warning", Time = "5pm", Color = Color.FromHex("#EEB611"), Completed = false },
                new Models.Task { Name = "Approve final design review", Category = "Mobile Project", Status = "Problem", Time = "4pm", Color = Color.FromHex("#5677CB"), Completed = false },                new Models.Task { Name = "Make new icons", Category = "Web App", Status = "Ready", Time = "3pm", Color = Color.FromHex("#51C6BF"), Completed = false },
                new Models.Task { Name = "Design explorations", Category = "Company Website", Status = "Delayed", Time = "2pm", Color = Color.FromHex("#EE376C"), Completed = false },
                new Models.Task { Name = "Lunch with Mary", Category = "Grill House", Status = "Ready", Time = "12pm", Color = Color.FromHex("#51C6BF"), Completed = false },
                new Models.Task { Name = "Team meeting", Category = "Hangouts", Status = "Ready", Time = "10am", Color = Color.FromHex("#51C6BF"), People = new List<Models.Person> { new Models.Person { Photo = "face2" }, new Models.Person { Photo = "face3" }, new Models.Person { Photo = "face4" }, new Models.Person { Photo = "face5" } }, Completed = false }
            };
        }
    }
}