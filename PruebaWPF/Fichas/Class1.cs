using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xaml;

namespace PruebaWPF.Fichas
{
    public abstract class AbFicha
    {
        public abstract string bando {get; set; }

        public abstract int posicion_X { get; set; }

        public abstract int posicion_Y { get; set; }

        public abstract string uid { get; set; }

        


        public abstract void Move();
        public abstract void Kill();

        public abstract void Die();

    }
}
