using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ShareModel
{
    public class Helper
    {

        public static string AddWhiteSpaceInTitleCase(string x)
        {
            return Regex.Replace(x.ToString(), @"(?<=[a-z])([A-Z])", @" $1");
        }


       


        public static string GetPenghasilanText(Penghasilan x)
        {
            switch (x)
            {
                case Penghasilan.KurangRP1:
                    return "< Rp.1.000.000";
                case Penghasilan.RP1TORP2:
                    return "Rp.1.000.000 - Rp.2.000.000";
                case Penghasilan.RP2To5:
                    return "Rp.2.000.000 - Rp.5.000.000";
                case Penghasilan.RP5TORP20:
                    return "Rp.5.000.000 - Rp.20.000.000";
                case Penghasilan.LebihRp20:
                    return "> Rp.20.000.000"; ;
                default:
                    return "Tidak Berpenghasilan";
            }

        }
    }

}
