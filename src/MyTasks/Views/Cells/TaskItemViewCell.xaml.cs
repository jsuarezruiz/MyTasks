using System;
using Xamarin.Forms;

namespace MyTasks.Views.Cells
{
    public partial class TaskItemViewCell : ViewCell
    {
        public TaskItemViewCell()
        {
            InitializeComponent();
        }

        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);

            uint duration = 750;

            // We are going to create a simple but nice animation. 
            // We will fade in at the same time we translade the cell view from the bottom to the top.
            var animation = new Animation();

            animation.WithConcurrent((f) => TaskItemTemplate.Opacity = f, 0, 1, Easing.CubicOut);

            animation.WithConcurrent(
              (f) => TaskItemTemplate.TranslationY = f,
              TaskItemTemplate.TranslationY + 50, 0,
              Easing.CubicOut, 0, 1);

            TaskItemTemplate.Animate("FadeIn", animation, 16, Convert.ToUInt32(duration));
        }
    }
}