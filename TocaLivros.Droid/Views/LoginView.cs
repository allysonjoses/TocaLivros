using MvvmCross.Droid.Support.V7.AppCompat;
using TocaLivros.Core.ViewModels;
using Android.Content.PM;
using Android.App;
using Android.OS;

namespace TocaLivros.Droid.Views
{
    [Activity(
         Theme = "@style/AppTheme",
         LaunchMode = LaunchMode.SingleTop,
         NoHistory = true,
         Name = "tocalivros.droid.views.loginview"
     )]
    public class LoginView : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.login_view);
        }

        public override void OnBackPressed() { Finish(); }
    }
}