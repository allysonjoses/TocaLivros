using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Shared.Attributes;
using Android.Support.Design.Widget;
using TocaLivros.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using System.Threading.Tasks;
using TocaLivros.Droid.Views;
using Android.Runtime;
using Android.Views;
using Android.OS;
using System;

namespace TocaLivros.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("tocalivros.droid.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (item != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }

            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate(item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainView)Activity).DrawerLayout.CloseDrawers();

            // add a small delay to prevent any UI issues
            await Task.Delay(TimeSpan.FromMilliseconds(250));

            switch (itemId)
            {
                case Resource.Id.nav_minha_conta:
                    ViewModel.ShowMinhaContaCommand.Execute();
                    break;
                case Resource.Id.nav_produtos:
                    ViewModel.ShowProdutosCommand.Execute();
                    break;
                case Resource.Id.nav_carrinho:
                    ViewModel.ShowCarrinhoCommand.Execute();
                    break;
                case Resource.Id.nav_pedidos:
                    ViewModel.ShowPedidosCommand.Execute();
                    break;
                case Resource.Id.nav_logout:
                    ViewModel.LogoutCommand.Execute();
                    break;
            }
        }
    }
}