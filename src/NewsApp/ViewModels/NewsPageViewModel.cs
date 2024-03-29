﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using NewsApp.Models;
using NewsApp.Network;
using NewsApp.Views;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Services;
using Xamarin.Forms;

namespace NewsApp.ViewModels
{
    public class NewsPageViewModel : ViewModelBase
    {
        private INavigation Navigation;
        INavigationService navigationService;
        List<FeedItemModel> items;

        public NewsPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService, IDeviceService deviceService) : base(navigationService, pageDialogService, deviceService)
        {
            this.navigationService = navigationService;
            this.GetNewsFeedAsync();
        }

        private async Task GetNewsFeedAsync()
        {
            NetworkManager manager = NetworkManager.Instance;

            List<FeedItemModel> result = await manager.GetSyncFeedAsync(); 
            Items = new List<FeedItemModel>(result);

        }

        public event PropertyChangedEventHandler PropertyChanged;


        private FeedItemModel selectedItem = null;
        public FeedItemModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                    OpenWebPage();
                }
            }
        }
        public List<FeedItemModel> Items
        {
            set { SetProperty(ref items, value); }
            get { return items; }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OpenWebPage()
        {
            var navigationParams = new Prism.Navigation.NavigationParameters();
            navigationParams.Add("url", selectedItem.Guid);
            navigationService.NavigateAsync("WebPage", navigationParams, animated: false);
        }
    }
}

