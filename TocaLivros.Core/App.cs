using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform;

namespace TocaLivros.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("TocaLivros.Core.Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            var appStart = Mvx.Resolve<IMvxAppStart>();

            RegisterAppStart(appStart);
        }
    }
}
