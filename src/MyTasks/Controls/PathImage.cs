using SkiaSharp;
using SkiaSharp.Views.Forms;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace MyTasks.Controls
{
    /// <summary>
    /// More information: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/curves/clipping
    /// TODO: Include Source and Path BindableProperties.
    /// </summary>
    public class PathImage : SKCanvasView
    {
        SKBitmap _bitmap;

        SKPath Path = SKPath.ParseSvgPathData("m 0 0 l 400 0 l 0 300 l -400 -50");

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            Path.GetBounds(out SKRect bounds);

            canvas.Scale(info.Width / bounds.Width);
            canvas.ClipPath(Path);
            canvas.ResetMatrix();

            string resourceID = "MyTasks.Images.birdsfly.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                _bitmap = SKBitmap.Decode(stream);
            }

            canvas.DrawBitmap(_bitmap, info.Rect);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldVal, object newVal)
        {
            var pathImage = bindable as PathImage;
            pathImage?.InvalidateSurface();
        }
    }
}