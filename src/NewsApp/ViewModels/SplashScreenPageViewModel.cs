using System.Threading.Tasks;
using Prism.AppModel;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class SplashScreenPageViewModel : ViewModelBase
    {
        public SplashScreenPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService)
            : base(navigationService, pageDialogService, deviceService)
        {
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            // TODO: Implement any initialization logic you need here. Example would be to handle automatic user login

            // Simulated long running task. You should remove this in your app.
            await Task.Delay(2000);

            // After performing the long running task we perform an absolute Navigation to remove the SplashScreen from
            // the Navigation Stack.

            if (Device.RuntimePlatform == Device.Android)
            {
                await _navigationService.NavigateAsync("NewsPage", animated: false);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                await _navigationService.NavigateAsync("MainPage/NewsPage", animated: false);

            }
        }
    }
}