using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;

namespace MyApplication
{
	public static class PersianConvertorDate
	{
		public static string toShamsi(this DateTime dateTime)
		{
			PersianCalendar persianCalendar = new PersianCalendar();
			return 
				persianCalendar.GetYear(dateTime) + "/" + 
				persianCalendar.GetMonth(dateTime).ToString("00") + "/" + 
				persianCalendar.GetDayOfMonth(dateTime).ToString("00");
		}
	}
}