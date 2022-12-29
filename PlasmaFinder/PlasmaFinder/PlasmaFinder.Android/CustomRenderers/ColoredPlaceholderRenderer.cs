using PlasmaFinder.Controls;
using Xamarin.Forms.Platform.Android;
using PlasmaFinder.Droid.CustomRenderers;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(ColoredPlaceholder), typeof(ColoredPlaceholderRenderer))]
namespace PlasmaFinder.Droid.CustomRenderers
{
    public class ColoredPlaceholderRenderer : EntryRenderer
    {
        public ColoredPlaceholderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetHintTextColor(Android.Graphics.Color.Gray);
                Control.Background = null;
                Control.SetPadding(Control.PaddingLeft, Control.PaddingTop, Control.PaddingRight, 4);
            }
        }
    }
}
