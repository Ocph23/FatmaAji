using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobieApp
{
    public class Helper
    {
        public static string Url { get; internal set; } = "https://sdninprestanjungria.apspapua.com/";
        //public static string Url { get; internal set; } = "https://pw8m897k-7113.asse.devtunnels.ms/";
        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
