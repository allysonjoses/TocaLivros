using MvvmCross.Droid.Support.V7.AppCompat;
using Android.Views.InputMethods;
using TocaLivros.Core.ViewModels;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Content.PM;
using Android.Views;
using Android.App;
using Android.OS;

namespace TocaLivros.Droid.Views
{
    [Activity(
       Label = "Toca Livros",
       Theme = "@style/AppTheme",
       NoHistory = false,
       LaunchMode = LaunchMode.SingleTop,
       Name = "tocalivros.droid.views.mainview"
   )]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        public Android.Support.V7.Widget.SearchView searchView;
        public DrawerLayout DrawerLayout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main_view);

            DrawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            if (bundle == null)
                ViewModel.ShowApp();
        }

       
        public void SetTitle(string title)
        {
            Title = title;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    DrawerLayout.OpenDrawer(GravityCompat.Start);
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void ShowBackButton()
        {
            //TODO Tell the toggle to set the indicator off
            //this.DrawerToggle.DrawerIndicatorEnabled = false;

            //Block the menu slide gesture
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
        }

        private void ShowHamburguerMenu()
        {
            //TODO set toggle indicator as enabled 
            //this.DrawerToggle.DrawerIndicatorEnabled = true;

            //Unlock the menu sliding gesture
            DrawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);
        }

        public override void OnBackPressed()
        {
            if (DrawerLayout != null && DrawerLayout.IsDrawerOpen(GravityCompat.Start))
                DrawerLayout.CloseDrawers();
            else
                base.OnBackPressed();
        }

        public void HideSoftKeyboard()
        {
            if (CurrentFocus == null) return;

            InputMethodManager inputMethodManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, 0);

            CurrentFocus.ClearFocus();
        }
    }
}