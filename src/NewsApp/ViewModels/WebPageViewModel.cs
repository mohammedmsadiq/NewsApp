using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class WebPageViewModel : ViewModelBase
    {
        INavigationService navigationService;
        public string Url { get; set; }
        public bool IsVisible { get; set; }

        public WebPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            this.navigationService = navigationService;
            if (Device.RuntimePlatform == Device.Android)
            {
                IsVisible = false;
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                IsVisible = true;
            }
            this.BackCommand = new DelegateCommand(this.BackCommandAction);
        }

        public ICommand BackCommand { get; set; }
        private void BackCommandAction()
        {
            navigationService.GoBackAsync();
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters == null || !parameters.ContainsKey("url"))
            {
                return;
            }
            else
            {
                Url = parameters.GetValue<string>("url");
            }
        }


        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }
    }
}

