using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobieApp.Models
{
    public class EnumModel<T> where T : struct, Enum
    {

        public EnumModel(T item, string v)
        {
            Value=item;
            Text=v;
        }

        public T Value { get; set; }
        public string Text { get; set; }
    }
}
