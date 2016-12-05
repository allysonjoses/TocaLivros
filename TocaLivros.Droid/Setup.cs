using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platform.Droid.Platform;
using MvvmCross.Droid.Shared.Presenter;
using System.Collections.Generic;
using TocaLivros.Droid.Utilities;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Platform;
using System.Reflection;
using Android.Content;

namespace TocaLivros.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext) { }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(Android.Support.Design.Widget.NavigationView).Assembly,
            typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
            typeof(Android.Support.V7.Widget.Toolbar).Assembly,
            typeof(Android.Support.V7.Widget.CardView).Assembly,
            typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
            typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
        };

        protected override IMvxApplication CreateApp() => new Core.App();

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);

            mvxFragmentsPresenter.AddPresentationHintHandler<MvxPanelPopToRootPresentationHint>(hint =>
            {
                var activity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>().Activity;
                var fragmentActivity = activity as Android.Support.V4.App.FragmentActivity;
                 
                for (int i = 0; i < fragmentActivity.SupportFragmentManager.BackStackEntryCount; i++) fragmentActivity.SupportFragmentManager.PopBackStack();

                return true;
            });
            Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
            return mvxFragmentsPresenter;
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }
    }
}
