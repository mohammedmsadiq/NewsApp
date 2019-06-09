using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NewsApp.Views
{
    public partial class WebPage : ContentPage
    {

        public string WebviewSource { get; set; }
        public WebPage()
        {
            InitializeComponent();

        }
        public WebPage(string s)
        {
            InitializeComponent();
            WebviewSource = s;
            Title = "Web";
            BindingContext = this;
        }
    }
}
