using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PruebaWPF.Fichas;

namespace PruebaWPF
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Rectangle[,] tablero = new Rectangle[4, 4];
        Ellipse[,] Fichas = new Ellipse[4, 4];
        Ellipse[] TeamR = new Ellipse[2];
        Ellipse[] TeamB = new Ellipse[2];
        FichaStandar fichaactual = new FichaStandar();
        int fila = 0;
        int columna = 0;
        bool blanc = false;
        
        public Window1()
        {
            InitializeComponent();

            //Inicializar Matriz del Tablero
            tablero[0, 0] = Rectangle;
            tablero[0, 1] = Rectangle1;
            tablero[0, 2] = Rectangle2;
            tablero[0, 3] = Rectangle3;
            tablero[1, 0] = Rectangle4;
            tablero[1, 1] = Rectangle5;
            tablero[1, 2] = Rectangle6;
            tablero[1, 3] = Rectangle7;
            tablero[2, 0] = Rectangle8;
            tablero[2, 1] = Rectangle_;
            tablero[2, 2] = Rectangle9;
            tablero[2, 3] = Rectangle10;
            tablero[3, 0] = Rectangle11;
            tablero[3, 1] = Rectangle12;
            tablero[3, 2] = Rectangle13;
            tablero[3, 3] = Rectangle14;

            //SE DEBE DE ACTUALIZAR LA POSICION E LA FICHA EN LA MATRIZ DE LAS FICHAS
            Fichas[0, 0] = Ficha;
            Fichas[0, 2] = Ficha1;
            Fichas[3, 1] = Ficha2;
            Fichas[3, 3] = Ficha3;

            TeamB[0] = Ficha;
            TeamB[1] = Ficha1;

            TeamR[0] = Ficha2;
            TeamR[1] = Ficha3;
        }


        //ITERAR SOBRE EL TABLERO
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txt.Text = $"Fila: { fila }, Columna: { columna }";

            if (columna == 0 && fila > 0)
            {
                if (blanc == true)
                {
                    tablero[fila - 1, 3].Fill = new SolidColorBrush(Colors.White);
                    blanc = false;
                }
                else
                {
                    tablero[fila - 1, 3].Fill = new SolidColorBrush(Colors.Black);
                    blanc = true;
                }
            }
            else if (columna == 0 && fila == 0)
            {

                tablero[3, 3].Fill = new SolidColorBrush(Colors.Black);
                blanc = false;

            }

            if (columna != 0)
            {
                if (blanc == true)
                {
                    tablero[fila, columna - 1].Fill = new SolidColorBrush(Colors.White);
                    blanc = false;
                }
                else
                {
                    tablero[fila, columna - 1].Fill = new SolidColorBrush(Colors.Black);
                    blanc = true;
                }
            }


            tablero[fila, columna].Fill = new SolidColorBrush(Colors.Aqua);

            //[fila, (columna = (columna == 0) ? columna = 3 : columna) -1]

            columna ++;
            if (columna > 3)
            {
                columna = 0;
                fila++;

                if (fila > 3)
                {
                    columna = 0;
                    fila = 0;
                }
            }
        }

        private void Ficha_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fichaactual.SetCurrentFicha(CasiilAactual(Ficha));

            txtInformationFicha.Text = $"Posicion: {fichaactual.posicion_X}{fichaactual.posicion_Y}; Bando: {fichaactual.bando}; Uid: {fichaactual.uid}";
        }


        private void Ficha1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fichaactual.SetCurrentFicha(CasiilAactual(Ficha1));

            txtInformationFicha.Text = $"Posicion: {fichaactual.posicion_X}{fichaactual.posicion_Y}; Bando: {fichaactual.bando}; Uid: {fichaactual.uid}";

        }

        private void Ficha2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fichaactual.SetCurrentFicha(CasiilAactual(Ficha2));

            txtInformationFicha.Text = $"Posicion: {fichaactual.posicion_X}{fichaactual.posicion_Y}; Bando: {fichaactual.bando}; Uid: {fichaactual.uid}";
        }

        private void Ficha3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            fichaactual.SetCurrentFicha(CasiilAactual(Ficha3));

            txtInformationFicha.Text = $"Posicion: {fichaactual.posicion_X}{fichaactual.posicion_Y}; Bando: {fichaactual.bando}; Uid: {fichaactual.uid}";
        }

        //METODO PARA OBTENER LA FICHA SELECCIONADA ACTUALMENTE
        private string[] CasiilAactual(Ellipse ficha)
        {
            //Detectar casilla cercana
            string[] currentficha = new string[4];
            string casilUid = "";
            string fichaUid = "";
            string bando = "";
            int x = 0; int y = 0;


            foreach (var casilla in tablero)
            {
                Point position = casilla.TranslatePoint(new Point(10, 10), ficha); // Calcula posicion relativa de la casilla con respecto a la ficha

                if ((position.X > -30 && position.X < 0) && (position.Y > -30 && position.Y < 0)) //Confirma si es la mas cercana
                {

                    casilUid = casilla.Uid; //Almacena la propiedad Uid de la casilla mas cercana

                    while (true)
                    {
                        
                        if(tablero[x, y].Uid == casilUid) //Busca la casilla en la matriz del tablero mediante Uid
                        {
                            fichaUid = Fichas[x, y].Uid; //Toma Uid de la Ficha mediante las coordenadas

                            for(int i = 0; i < TeamB.Length; i++) //Busca en cada bando la ficha seleccionada
                            {
                                if (TeamB[i].Uid == fichaUid)
                                {
                                    bando = "Blue";
                                    break;
                                }

                                if (TeamR[i].Uid == fichaUid)
                                {
                                    bando = "Red";
                                    break;
                                }
                            }

                            currentficha[0] = x.ToString();
                            currentficha[1] = y.ToString();
                            currentficha[2] = bando;
                            currentficha[3] = fichaUid;
                            break;
                        }

                        y++;

                        if (y > 3)
                        {
                            y = 0;
                            x++;
                        }

                        if (x > 3)
                        {
                            x = 0;
                            break;
                        }

                        
                    }

                    if (fichaUid != "")
                    {
                        break;
                    }
                    

                }

            }

            return currentficha;

        }

        //Eventos click de las casillas

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle);
        }

        private void Rectangle1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle1);
        }

        private void Rectangle2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle2);
        }

        private void Rectangle3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle3);
        }

        private void Rectangle4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle4);
        }

        private void Rectangle5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle5);
        }

        private void Rectangle6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle6);
        }

        private void Rectangle7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle7);
        }

        private void Rectangle8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle8);
        }

        private void Rectangle__MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle_);
        }

        private void Rectangle9_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle9);
        }

        private void Rectangle10_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle10);
        }

        private void Rectangle11_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle11);
        }

        private void Rectangle12_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle12);
        }

        private void Rectangle13_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle13);
        }

        private void Rectangle14_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            moveficha(Rectangle14);
        }

        //Metodo mover ficha actual

        private void moveficha(Rectangle Casilla)
        {

            TranslateTransform trans = new TranslateTransform();
            Ellipse fi = Fichas[fichaactual.posicion_X, fichaactual.posicion_Y];

            Point position = Casilla.TranslatePoint(new Point(20, 20), fi);





            trans.Y = position.Y;
            trans.X = position.X;
            fi.RenderTransform = trans;


            int x = 0;
            int y = 0;
            while (true)
            {

                if (tablero[x, y].Uid == Casilla.Uid) //Busca la casilla en la matriz del tablero mediante Uid
                {
                    Fichas[fichaactual.posicion_X, fichaactual.posicion_Y] = null;
                    Fichas[x, y] = fi;
                    fichaactual.QuitFichaActual();
                    break;
                }

                y++;

                if (y > 3)
                {
                    y = 0;
                    x++;
                }

                if (x > 3)
                {
                    x = 0;
                    break;
                }


            }

        }




    }


    

}