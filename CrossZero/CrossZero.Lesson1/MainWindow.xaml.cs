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

namespace CrossZero.Lesson1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttons = new []{ button11, button12, button13, button21, button22, button23, button31, button32, button33 };

            foreach (var i in buttons)
            {

                i.Click += I_Click;
            }
        }
        string user = "";
        string computer = "";
        Button[] buttons;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Button[] buttons = { button11, button12, button13, button21, button22, button23, button31, button32, button33 };
            foreach (var i in buttons)
            {
                i.IsEnabled = true;
                i.Content = "";
            }
            

            if (checkO.IsChecked == true && checkX.IsChecked != true)
            {
                ComputerPlay();
            }

            else if (checkO.IsChecked == checkX.IsChecked)
            { MessageBox.Show("Выберите маркер"); }


        }


        private bool Wins()
        {
            if (((string)button11.Content != "" && button11.Content == button12.Content && button11.Content == button13.Content)
                || ((string)button11.Content != "" && button11.Content == button21.Content && button11.Content == button31.Content)
                || ((string)button12.Content != "" && button12.Content == button22.Content && button12.Content == button32.Content)
                || ((string)button13.Content != "" && button13.Content == button23.Content && button13.Content == button33.Content)
                || ((string)button21.Content != "" && button21.Content == button22.Content && button21.Content == button23.Content)
                || ((string)button31.Content != "" && button31.Content == button32.Content && button31.Content == button33.Content)
                || ((string)button11.Content != "" && button11.Content == button22.Content && button11.Content == button33.Content)
                || ((string)button13.Content != "" && button13.Content == button22.Content && button13.Content == button31.Content))
            {
                return true;
            }
            else return false;
        }

        private void EndGame()
        {
            foreach (var j in buttons)
            {
                j.IsEnabled = false;
            }
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = user;

            if (Wins())
            {
                MessageBox.Show("Вы выиграли");
                EndGame();
                
            }
            else ComputerPlay();
        }

        private void CheckX_Checked(object sender, RoutedEventArgs e)
        {
            this.user = "X";
            this.computer = "O";

        }

        private void CheckO_Checked(object sender, RoutedEventArgs e)
        {
            this.user = "O";
            this.computer = "X";
        }

        private void ComputerPlay()
        {
            foreach (var i in buttons)
            {
                if ((string)i.Content == "")
                {
                    i.Content = this.computer;
                    i.IsEnabled = false;
                    if (Wins())
                    {
                        MessageBox.Show("Вы проиграли");
                        EndGame();
                    }
                    return;
                }
            }

            MessageBox.Show("Ничья!");
            EndGame();
                
            }
        }



    }

