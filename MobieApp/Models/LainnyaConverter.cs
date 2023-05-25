using CommunityToolkit.Maui.Converters;
using FluentValidation.Results;
using ShareModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Models
{
    public class LainnyaConverter : BaseConverterOneWay<object, bool, string>
    {
        public override bool DefaultConvertReturnValue
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override bool ConvertFrom(object value, string parameter, CultureInfo culture)
        {
            if (value is EnumModel<Kewarganegaraan> wna && wna.Value == Kewarganegaraan.WNA)
            {
                return true;
            }

            if (value is EnumModel<TempatTinggal> tempatTinggal && tempatTinggal.Value ==  TempatTinggal.Lainnya)
            {
                return true;
            }


            if (value is EnumModel<ModaTransportasi> moda && moda.Value ==  ModaTransportasi.Lainnya)
            {
                return true;
            }


            return false;
        }

    }
}
