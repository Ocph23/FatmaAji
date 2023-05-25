using CommunityToolkit.Maui.Converters;
using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Models
{
    public class FluentErrorShowTextConverter : BaseConverterOneWay<IEnumerable, bool, string>
    {
        public override bool DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override bool ConvertFrom(IEnumerable value, string parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            var collection = value
                .OfType<ValidationFailure>()
                .Select(x => x);
            var dataFound = collection.SingleOrDefault(x => x.PropertyName == parameter);
            return dataFound != null ? true : false;
        }
    }
}
