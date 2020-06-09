using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BoogieApp.Converters
{
    class ProgressColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			string orders = value as string;
			if(orders == "Pending")
			{
				return Color.FromHex("#FF9800");
			}
			else if(orders == "Completed")
			{
				return Color.Green;
			}
			else
			{
				return Color.FromHex("#FF0000");
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
