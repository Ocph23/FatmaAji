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
        public static string Url { get; internal set; } = "https://z8xrt027-7113.asse.devtunnels.ms/";
        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
