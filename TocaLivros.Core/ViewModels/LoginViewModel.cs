using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using System;

namespace TocaLivros.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private string _username;

        public string Username
        {
            get { return _username; }

            set
            {
                SetProperty(ref _username, value);
                RaisePropertyChanged(() => Username);
            }
        }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get { return _isLoading; }

            set
            {
                SetProperty(ref _isLoading, value);
                RaisePropertyChanged(() => IsLoading);
            }
        }

        public ICommand LogarCommand
        {
            get
            {
                return new MvxCommand(() =>
                {
                    //try
                    //{
                    //    IsLoading = true;
                    //    await _login.LoginAsync(Username, Password);

                        ShowViewModel<MainViewModel>();
                    //}
                    //catch (Exception ex) { _dialog.Error(ex.Message); }
                    //finally { IsLoading = false; }
                });
            }
        }
    }
}
