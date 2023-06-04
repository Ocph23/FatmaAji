using Radzen;
using ShareModel;

namespace WebApp
{
    public class WebHelper
    {
        public static ButtonStyle GetStatusColor(StatusPenerimaan status)
        {
            switch (status)
            {
                case StatusPenerimaan.Lulus:
                    return ButtonStyle.Success;

                case StatusPenerimaan.TidakLulus:
                    return ButtonStyle.Danger;

                case StatusPenerimaan.Menunggu:
                    return ButtonStyle.Warning;
                default:
                    return ButtonStyle.Light;
            }
        }


        public static IconStyle GetIconColor(StatusPenerimaan status)
        {
            switch (status)
            {
                case StatusPenerimaan.Lulus:
                    return IconStyle.Success;

                case StatusPenerimaan.TidakLulus:
                    return IconStyle.Danger;

                case StatusPenerimaan.Menunggu:
                    return IconStyle.Warning;
                default:
                    return IconStyle.Light;
            }
        }


        public static string GetStatusIcon(StatusPenerimaan status)
        {
            switch (status)
            {
                case StatusPenerimaan.Lulus:
                    return "check";

                case StatusPenerimaan.TidakLulus:
                    return "highlight_off";

                case StatusPenerimaan.Menunggu:
                    return "pending";
                default:
                    return "details";
            }
        }


    }
}
