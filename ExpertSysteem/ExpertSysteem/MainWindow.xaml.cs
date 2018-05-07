using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpertSysteem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //adding values to comboboxes
            cbIntrMot.Items.Add(0);
            cbIntrMot.Items.Add(1);
            cbIntrMot.Items.Add(2);
            cbIntrMot.Items.Add(3);
            cbIntrMot.Items.Add(4);
            cbIntrMot.Items.Add(5);
            cbIntrMot.Items.Add(6);
            cbIntrMot.Items.Add(7);
            cbIntrMot.Items.Add(8);
            cbIntrMot.Items.Add(9);
            cbIntrMot.Items.Add(10);
            cbExtrMot.Items.Add(0);
            cbExtrMot.Items.Add(1);
            cbExtrMot.Items.Add(2);
            cbExtrMot.Items.Add(3);
            cbExtrMot.Items.Add(4);
            cbExtrMot.Items.Add(5);
            cbExtrMot.Items.Add(6);
            cbExtrMot.Items.Add(7);
            cbExtrMot.Items.Add(8);
            cbExtrMot.Items.Add(9);
            cbExtrMot.Items.Add(10);
            cbComp.Items.Add(0);
            cbComp.Items.Add(1);
            cbComp.Items.Add(2);
            cbComp.Items.Add(3);
            cbComp.Items.Add(4);
            cbComp.Items.Add(5);
            cbComp.Items.Add(6);
            cbComp.Items.Add(7);
            cbComp.Items.Add(8);
            cbComp.Items.Add(9);
            cbComp.Items.Add(10);          
            cbCap.Items.Add(0);
            cbCap.Items.Add(1);
            cbCap.Items.Add(2);
            cbCap.Items.Add(3);
            cbCap.Items.Add(4);
            cbCap.Items.Add(5);
            cbCap.Items.Add(6);
            cbCap.Items.Add(7);
            cbCap.Items.Add(8);
            cbCap.Items.Add(9);
            cbCap.Items.Add(10);
            cbAantW.Items.Add(0);
            cbAantW.Items.Add(1);
            cbAantW.Items.Add(2);
            cbAantW.Items.Add(3);
            cbTraject.Items.Add("Regulier");
            cbTraject.Items.Add("Verkort");
            cbGeslacht.Items.Add("M");
            cbGeslacht.Items.Add("V");
            cbDeficient.Items.Add("Ja");
            cbDeficient.Items.Add("Nee");
            cbUit.Items.Add("Ja");
            cbUit.Items.Add("Nee");



        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //score opsetten en values uit cb halen.
            int score = 0;
            int scoreneeded = 0;
            string advies = "";

            //traject bepalen en adhv het opgegeven traject het aantal benodigde punten opstellen
            string traject = cbTraject.SelectedValue.ToString();
            if(traject == "Regulier")
            {
                scoreneeded = 7;
            } else if (traject == "Verkort")
            {
                scoreneeded = 9;
            }else
            {
                MessageBox.Show("Gelieve het gewenste traject in te vullen.");
            }

            int capaciteiten = Convert.ToInt32(cbCap.SelectedValue.ToString());
            int competenties = Convert.ToInt32(cbComp.SelectedValue.ToString());
            int intrMot = Convert.ToInt32(cbIntrMot.SelectedValue.ToString());
            int extrMot = Convert.ToInt32(cbExtrMot.SelectedValue.ToString());
            Boolean Opleiding = checkOpleiding(txtVooropleiding.Text , txtVoorkeur.Text);
            Boolean Deficient = checkMBO();

            //checken hoe vaak de student al geweigert is. het aantal word meegenomen in de toelatingsscore.
            int weigercount = Convert.ToInt32(cbAantW.SelectedValue.ToString());
            score = score - weigercount;

            //algoritme score uitrekeken met criteria.
            if (capaciteiten > 5 && capaciteiten <=7  )
            {
                score = score + 2;
            }else if(capaciteiten >= 8)
            {
                score = score + 4;
            }
            else
            {
                score = score - 2;
            }

            if (competenties > 5 && competenties <= 7)
            {
                score = score + 2;
            }
            else if (competenties > 7)
            {
                score = score + 4;
            }
            else
            {
                score = score - 2;
            }

            if (intrMot > extrMot && intrMot >=6)
            {
                score = score + 2;
            }else if(extrMot >= intrMot && intrMot >=5)
            {
                score = score + 1;
            }
            else
            {
                score = score - 2;
            }

            if(cbUit.SelectedValue.ToString() == "Ja")
            {
                score = score - 1;
            }

            if(Opleiding == true && Deficient == false)
            {
                score = score + 2;
            }
            else if(Opleiding == false && Deficient == false)
            {
                score = score + 1;
            }
            else if(Opleiding == true && Deficient == true)
            {
                score = score - 2;
            }
            else { score = score - 2; }

            if(Deficient == true)
            {
                score = score - 2;
            } else
            {
                score = score + 2;
            }
           if(score >= scoreneeded)
            {
                advies = "Positief";
            }else if (score == scoreneeded - 3 || score == scoreneeded - 2 || score == scoreneeded -1 || score == scoreneeded -4)
            {
                advies = "Twijfel";
            } else { advies = "Negatief"; }

            // score laten zien.
            MessageBox.Show("Traject: " + traject + " Score: " + score.ToString() + " Advies: " + advies);
        } 
        
        public Boolean checkOpleiding(string current , string requested)
        {
           if(current == requested)
            {
                return true;
            }
           else
            {
                return false;
            }
           
        }
        public Boolean checkMBO()
        {
            if(cbDeficient.SelectedValue.ToString() == "Ja")
            {
                return true;
            } else
            {

            return false;
            }
        }

    }
}