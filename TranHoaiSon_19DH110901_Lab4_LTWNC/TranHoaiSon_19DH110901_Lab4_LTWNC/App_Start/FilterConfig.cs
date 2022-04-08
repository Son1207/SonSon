using System.Web;
using System.Web.Mvc;

namespace TranHoaiSon_19DH110901_Lab4_LTWNC
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
