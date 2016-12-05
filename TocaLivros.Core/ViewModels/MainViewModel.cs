namespace TocaLivros.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public void ShowApp()
        {
            ShowViewModel<MinhaContaViewModel>();
            ShowViewModel<MenuViewModel>();
        }
    }
}
