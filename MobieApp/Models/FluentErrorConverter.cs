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
    public class FluentErrorConverter : BaseConverterOneWay<IEnumerable, string, string>
    {
        public override string DefaultConvertReturnValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override string ConvertFrom(IEnumerable value, string parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;
            var collection = value
                .OfType<ValidationFailure>()
                .Select(x => x);


            var dataFound = collection.SingleOrDefault(x => x.PropertyName == parameter);
            return dataFound!=null ? dataFound.ErrorMessage : string.Empty;
        }
    }
}
