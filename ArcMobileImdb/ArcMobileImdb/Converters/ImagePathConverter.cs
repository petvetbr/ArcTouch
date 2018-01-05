using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcMobileImdb.Converters
{
   public class ImagePathConverter:IValueConverter,IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            int size = (parameter as int?)?? 500;
            var source = new UriImageSource {Uri = new Uri($"{Constants.IMAGE_BASE_URL}w{size}{value}")};
            return source;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private ImagePathConverter _instance;
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return _instance ?? (_instance = new ImagePathConverter());
        }
    }
}
