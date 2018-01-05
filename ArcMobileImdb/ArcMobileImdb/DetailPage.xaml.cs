using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi.MovieDb.Movies;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcMobileImdb
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Movie eSelectedItem)
        {
           
            InitializeComponent();
            BindingContext = eSelectedItem;
            this.Title = eSelectedItem.Title;
        }
    }
}