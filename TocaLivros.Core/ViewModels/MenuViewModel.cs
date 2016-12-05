using MvvmCross.Core.ViewModels;
using TocaLivros.Core.Helpers;

namespace TocaLivros.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public string Username
        {
            get { return Settings.Usuario; }
        }

        public IMvxCommand LogoutCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    Settings.Logout();
                    ShowViewModel<LoginViewModel>();
                });
            }
        }

        public IMvxCommand ShowProdutosCommand
        {
            get
            {
                return new MvxCommand(() => 
                {
                    ShowViewModel<ProdutosViewModel>();
                });
            }
        }

        public IMvxCommand ShowMinhaContaCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<MinhaContaViewModel>();
                });
            }
        }

        public IMvxCommand ShowCarrinhoCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<CarrinhoDeComprasViewModel>();
                });
            }
        }

        public IMvxCommand ShowPedidosCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    ShowViewModel<PedidosViewModel>();
                });
            }
        }
    }
}
