using TocaLivros.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using TocaLivros.Core.Helpers;

namespace TocaLivros.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        public AppStart()
        {

        }

        public void Start(object hint = null)
        {
            if (Settings.IsAuthenticated()) ShowViewModel<MainViewModel>();
            else ShowViewModel<LoginViewModel>();
        }
    }
}
