using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace PruebaWPF.Fichas
{
    public class FichaStandar : AbFicha
    {
        public override string bando { get; set; }
        public override int posicion_X { get; set; }

        public override int posicion_Y { get; set; }

        public override string uid { get ; set; }

        public FichaStandar()
        {
            posicion_X = -1;
            posicion_Y = -1;
            bando = "";
            uid = "";
        }


        public void SetCurrentFicha(string[] ficha)
        {
            posicion_X = Convert.ToInt16(ficha[0]);
            posicion_Y = Convert.ToInt16(ficha[1]);
            bando = ficha[2];
            uid = ficha[3];
        
        
        }

        public void QuitFichaActual()
        {
            posicion_X = -1;
            posicion_Y = -1;
            bando = "";
            uid = "";
        }


        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void Kill()
        {
            throw new NotImplementedException();
        }

        public override void Die()
        {
            throw new NotImplementedException();
        }
    }
}
