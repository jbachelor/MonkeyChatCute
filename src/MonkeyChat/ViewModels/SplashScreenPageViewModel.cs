using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;

namespace MonkeyChat.ViewModels
{

    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService, IApplicationStore applicationStore, IDeviceService deviceService)
            : base(navigationService, applicationStore, deviceService)
        {
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            // TODO: Implement any initialization logic you need here. Example would be to handle automatic user login

            // Simulated long running task. You should remove this in your app.
            await Task.Delay(4000);

            // After performing the long running task we perform an absolute Navigation to remove the SplashScreen from
            // the Navigation Stack.
            await _navigationService.NavigateAsync("/NavigationPage/ChatPage");
        }
    }
}