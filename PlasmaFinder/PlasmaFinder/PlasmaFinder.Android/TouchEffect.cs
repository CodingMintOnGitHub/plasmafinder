using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("PlasmaFinder")]
[assembly: ExportEffect(typeof(PlasmaFinder.Droid.TouchEffect), "TouchEffect")]
namespace PlasmaFinder.Droid
{
    public class TouchEffect : PlatformEffect
    {
        Android.Views.View view;
        Android.Graphics.Color originalBgColor;
        Android.Graphics.Color onTapBgColor;
        protected override void OnAttached()
        {
            // Get the Android View corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            Effects.TouchEffect touchEffect =
                (Effects.TouchEffect)Element.Effects.
                    FirstOrDefault(e => e is Effects.TouchEffect);

            if (touchEffect != null && view != null)
            {
                originalBgColor = touchEffect.BackgroundColor.ToAndroid();
                onTapBgColor = touchEffect.TapBackgroundColor.ToAndroid();

                // Set event handler on View
                view.Touch += OnTouch;
            }
        }

        private void OnTouch(object sender, Android.Views.View.TouchEventArgs args)
        {
            try
            {


            // object common to all the events
            Android.Views.View senderView = sender as Android.Views.View;

            // Use ActionMasked here rather than Action to reduce the number of possibilities
            switch (args.Event.Action)
            {
                case MotionEventActions.Down:
                case MotionEventActions.PointerDown:
                    //change color
                    senderView.SetBackgroundColor(onTapBgColor);
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Pointer1Up:
                    //set original color
                    senderView.SetBackgroundColor(originalBgColor);
                    break;
            }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected override void OnDetached()
        {
            view.Touch -= OnTouch;
        }
    }
}