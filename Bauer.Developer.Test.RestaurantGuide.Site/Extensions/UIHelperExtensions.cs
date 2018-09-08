using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bauer.Developer.Test.RestaurantGuide.Domain.Extensions
{
    public static class UIHelperExtensions
    {
        public static System.Web.Mvc.SelectList ToSelectList<TEnum>(this TEnum obj)
    where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return new SelectList(Enum.GetValues(typeof(TEnum))
            .OfType<Enum>()
            .Select(x => new SelectListItem
            {
                Text = Enum.GetName(typeof(TEnum), x),
                Value = (Convert.ToInt32(x))
                .ToString()
            }), "Value", "Text");
        }
    }
}
