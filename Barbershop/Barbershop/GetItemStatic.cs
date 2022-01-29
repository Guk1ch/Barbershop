using Barbershop.MyClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Barbershop
{
    public static class GetItemStatic
    {
        public static Client ClientAuth { get; set; }
        public static List<Service> ClientServices { get; set; } = new List<Service>();
    }
}
