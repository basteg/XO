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
            game = new LogicGame();
            InitializeComponent();
            button11.Tag = 0;
            button12.Tag = 1;
            button13.Tag = 2;
            button21.Tag = 3;
            button22.Tag = 4;
            button23.Tag = 5;
            button31.Tag = 6;
            button32.Tag = 7;
            button33.Tag = 8;
            buttons = new[] { button11, button12, button13, button21, button22, button23, button31, button32, button33 };

            foreach (var i in buttons)
            {
                i.Click += I_Click;
            }
        }
        LogicGame game;
        string user = "";
        string computer = "";
        Button[] buttons;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            game.Start();
            foreach (var i in buttons)
            {
                i.IsEnabled = true;
                i.Content = "";
            }

            if (checkX.IsChecked==true && checkO.IsChecked== false)
            {
                Reload(game.state, false);
            }

            else if (checkO.IsChecked == true && checkX.IsChecked != true)
            {
                Reload(game.state, true);
            }

            else 
            { MessageBox.Show("Выберите маркер"); }

        }

        private void Reload(StateGame state, bool doComputerStep)
        {
            var field = game.fields;
            for (int i = 0; i < field.Length; i++)
            {

                // Ищем среди всех элементов формы элемент с нужным названием (button + (i + 1)), это будет кнопка
                //var button = ((Button)Controls.Find("button" + (i + 1), false)[0]);
                var button = buttons[i];
                // определяем, каким значением ее заполнять
                button.Content = field[i] == FieldGame.UserField ? user : field[i] == FieldGame.CompField ? computer : "";
            }
            switch (game.state)
            {
                case StateGame.NotStart:
                    MessageBox.Show("Игра не началась");
                    break;
                case StateGame.NoWin:
                    MessageBox.Show("Ничья");
                    EndGame();
                    break;
                case StateGame.CompWin:
                    MessageBox.Show("Компьютер выиграл");
                    EndGame();
                    break;
                case StateGame.UserWin:
                    MessageBox.Show("Вы выиграли");
                    EndGame();
                    break;
                case StateGame.InProgress:
                    text1.Content = "Игра в процессе";
                    if (doComputerStep)
                    {
                        Reload(game.Step(ComputerPlay(game.fields), FieldGame.CompField), false);
                    }
                    break;
            }
        }

        private int ComputerPlay(FieldGame[] fields)
        {
            for (int i = 0; i < fields.Length; ++i)
            {
                if (fields[i] == FieldGame.EmptyField)
                {
                    return i;
                }
            }
            return -1;
        }

        //private bool Wins()
        //{
        //    if (((string)button11.Content != "" && button11.Content == button12.Content && button11.Content == button13.Content)
        //        || ((string)button11.Content != "" && button11.Content == button21.Content && button11.Content == button31.Content)
        //        || ((string)button12.Content != "" && button12.Content == button22.Content && button12.Content == button32.Content)
        //        || ((string)button13.Content != "" && button13.Content == button23.Content && button13.Content == button33.Content)
        //        || ((string)button21.Content != "" && button21.Content == button22.Content && button21.Content == button23.Content)
        //        || ((string)button31.Content != "" && button31.Content == button32.Content && button31.Content == button33.Content)
        //        || ((string)button11.Content != "" && button11.Content == button22.Content && button11.Content == button33.Content)
        //        || ((string)button13.Content != "" && button13.Content == button22.Content && button13.Content == button31.Content))
        //    {
        //        return true;
        //    }
        //    else return false;
        //}

        //private bool NoWiners()
        //{
        //    foreach (var i in buttons)
        //    {
        //        if ((string)i.Content == "")
        //        { return false; }
        //    }
        //    return true;
        //}

        private void EndGame()
        {
            foreach (var j in buttons)
            {
                j.IsEnabled = false;
            }
        }

        private void I_Click(object sender, RoutedEventArgs e)
        {

            Reload(game.Step(Convert.ToInt32(((Button)sender).Tag), FieldGame.UserField), true);
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

       
    }
}

