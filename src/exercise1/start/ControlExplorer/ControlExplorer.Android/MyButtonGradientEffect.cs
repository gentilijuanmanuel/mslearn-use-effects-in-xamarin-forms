using Android.Graphics.Drawables;
using ControlExplorer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.Droid
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;

        protected override void OnAttached()
        {
            // Element is the Xamarin.Forms UI component
            if (!(this.Element is Button))
                return;

            // Control is the platform specific UI component
            this.oldDrawable = this.Control.Background;

            this.SetGradient();
        }

        protected override void OnDetached()
        {
            if (oldDrawable != null)
                this.Control.Background = oldDrawable;
        }

        private void SetGradient()
        {
            var button = (Button)this.Element;
            var buttonColorTop = button.BackgroundColor;
            var buttonColorBottom = Color.Black;

            this.Control.SetBackground(Gradient.GetGradientDrawable(buttonColorTop.ToAndroid(), buttonColorBottom.ToAndroid()));
        }
    }
}
