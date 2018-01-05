using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DM.MovieApi.MovieDb.Genres;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcMobileImdb.Converters
{
    public class GenreDescriptionConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var genres = value as IReadOnlyList<Genre>;
            return genres?.FirstOrDefault()?.Name;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private static GenreDescriptionConverter _instance;
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new GenreDescriptionConverter());
        }
    }
}
