using MvvmCross.Droid.Shared.Attributes;
using TocaLivros.Core.ViewModels;
using TocaLivros.Droid.Views;
using Android.Runtime;
using Android.Views;
using Android.OS;

namespace TocaLivros.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.main_frame, true)]
    [Register("tocalivros.droid.fragments.PedidosFragment")]
    public class PedidosFragment : BaseFragment<PedidosViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            ShowHamburgerMenu = true;
            ((MainView)Activity).SetTitle("Pedidos");

            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId => Resource.Layout.fragment_pedidos;
    }
}