using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2._1.BLL.Util
{
    public class Events
    {
        public delegate void MethodContainer();

        public event MethodContainer dataChanged;

        public void DataChanged()
        {
            dataChanged();
        }
    }
}
