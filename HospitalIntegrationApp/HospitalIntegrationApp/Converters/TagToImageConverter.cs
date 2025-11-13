using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace HospitalIntegrationApp.Converters
{
    public class TagToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tag = value as string;
            if (string.IsNullOrWhiteSpace(tag)) return null;

            // Pack URI to embedded Resource in Images folder
            // Prefer assembly component pack URI for resources
            var uriStringComponent = $"/HospitalIntegrationApp;component/Images/{tag}.png";
            try
            {
                var uri = new Uri(uriStringComponent, UriKind.Relative);
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = uri;
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.EndInit();
                return bmp;
            }
            catch
            {
                try
                {
                    // Fallback to absolute pack URI
                    var fallback = new Uri($"pack://application:,,,/Images/{tag}.png", UriKind.Absolute);
                    var bmp = new BitmapImage();
                    bmp.BeginInit();
                    bmp.UriSource = fallback;
                    bmp.CacheOption = BitmapCacheOption.OnLoad;
                    bmp.EndInit();
                    return bmp;
                }
                catch
                {
                    return null;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}


