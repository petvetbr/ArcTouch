using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArcMobileImdb.ViewModels;
using DM.MovieApi.MovieDb.Movies;
using Xamarin.Forms;

namespace ArcMobileImdb
{
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _vm;

        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this,false);
            InitializeComponent();
            _vm = new MainViewModel();
            this.Appearing += MainPage_Appearing;
        }

        private void MainPage_Appearing(object sender, EventArgs e)
        {
            _vm.Load();
            BindingContext = _vm;
        }

        private void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (_vm?.MovieList == null) return;
            if (e.Item==_vm.MovieList.Last()) _vm.Load();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new DetailPage((Movie)e.SelectedItem));
        }
    }
}
