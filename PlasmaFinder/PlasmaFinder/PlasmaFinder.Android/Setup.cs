
using MvvmCross.Forms.Platforms.Android.Core;
using Xamarin.Forms;

namespace PlasmaFinder.Droid
{
    public class Setup : MvxFormsAndroidSetup<CoreApp, App>
    {
        protected override Application CreateFormsApplication()
        {
            return base.CreateFormsApplication();
        }
    }
}