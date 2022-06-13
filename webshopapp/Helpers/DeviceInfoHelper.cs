using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopapp.Helpers
{
    public static class DeviceInfoHelper
    {
        public static string BaseAddress =
           DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:7150" : "https://localhost:7150";

        public static string BaseUrl = $"{BaseAddress}/api";
    }
}
