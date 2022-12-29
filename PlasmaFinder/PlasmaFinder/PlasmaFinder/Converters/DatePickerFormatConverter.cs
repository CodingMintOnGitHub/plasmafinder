using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PlasmaFinder.Converters
{
    public class DatePickerFormatConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string incomingDateString = value.ToString();
            if (incomingDateString == "No Filter")
            {
                return incomingDateString;
            }

            string outgoingDateString = DateTime.ParseExact(incomingDateString, "MM/dd/yyyy hh:mm:ss", null).ToString("dd-MM-yyyy");
            return outgoingDateString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
