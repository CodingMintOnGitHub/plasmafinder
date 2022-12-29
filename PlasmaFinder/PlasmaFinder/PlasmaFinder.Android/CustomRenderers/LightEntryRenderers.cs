using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Graphics;
using PlasmaFinder.Controls;
using PlasmaFinder.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(LightEntry), typeof(LightEntryRenderers))]
namespace PlasmaFinder.Droid.CustomRenderers
{
    public class LightEntryRenderers : EntryRenderer
    {
        public LightEntryRenderers(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = null;
                Control.SetPadding(Control.PaddingLeft, Control.PaddingTop, Control.PaddingRight, 4);
                Control.SetHintTextColor(Android.Graphics.Color.ParseColor("#333333"));
            }
        }
    }
}
