using System.ComponentModel;
using ControlExplorer.iOS;
using CoreAnimation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(MyButtonGradientEffect), "ButtonGradientEffect")]
namespace ControlExplorer.iOS
{
    public class MyButtonGradientEffect : PlatformEffect
    {
        CAGradientLayer gradLayer;

        protected override void OnAttached()
        {
            if (!(this.Element is Button))
                return;

            this.SetGradient();
        }

        protected override void OnDetached()
        {
            if (this.gradLayer != null)
                this.gradLayer.RemoveFromSuperLayer();
        }

        private void SetGradient()
        {
            this.gradLayer?.RemoveFromSuperLayer();

            var button = (Button)this.Element;
            var buttonColorTop = button.BackgroundColor;
            var buttonColorBottom = ButtonGradientEffect.GetGradientColor(button);

            this.gradLayer = Gradient.GetGradientLayer(buttonColorTop.ToCGColor(), buttonColorBottom.ToCGColor(), (float)button.Width, (float)button.Height);

            this.Control.Layer.InsertSublayer(this.gradLayer, 0);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (Element is Button == false)
                return;

            if (e.PropertyName == ButtonGradientEffect.GradientColorProperty.PropertyName)
                SetGradient();
        }
    }
}
