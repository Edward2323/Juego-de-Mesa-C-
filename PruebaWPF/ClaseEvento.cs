using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaWPF
{
    internal class ClaseEvento
    {
        public event EventHandler Algo;

        protected virtual void OnAlgo(EventArgs e)
        {
            EventHandler handler = Algo;
            handler?.Invoke(this, e);
        }


    }
}