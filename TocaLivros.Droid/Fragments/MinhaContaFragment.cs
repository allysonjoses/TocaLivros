using MvvmCross.Droid.Shared.Attributes;
using TocaLivros.Core.ViewModels;
using TocaLivros.Droid.Views;
using Android.Runtime;
using Android.Views;
using Android.OS;

namespace TocaLivros.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.main_frame, true)]
    [Register("tocalivros.droid.fragments.MinhaContaFragment")]
    public class MinhaContaFragment : BaseFragment<MinhaContaViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            ((MainView)Activity).SetTitle("Minha Conta");

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_minha_conta;
    }
}