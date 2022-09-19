using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Shell;

namespace replacingBooksPrototype
{
    public partial class ReplacingBooks : Window
    {
        //Generate a list of 10 random call numbers
        public List<CallNumber> list = new List<CallNumber>();

        public ReplacingBooks()
        {
            InitializeComponent();
            GenerateRandom(list);
            PrintList(list);
        }

        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            //User selected submit
            if (firstinput.Text != null && secondinput.Text != null)
            {
                try
                {
                    string input1 = firstinput.Text;
                    string input2 = secondinput.Text;
                    int swap1 = Convert.ToInt32(input1) - 1;
                    int swap2 = Convert.ToInt32(input2) - 1;

                    string temp = list[swap1].Value;
                    list[swap1].Value = list[swap2].Value;
                    list[swap2].Value = temp;

                    firstinput.Clear();
                    secondinput.Clear();

                    PrintList(list);
                    CheckList(list);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Input");
                    firstinput.Clear();
                    secondinput.Clear();
                } 
            }
            else
            {
                MessageBox.Show("Please input both values");
            }
        }

        private void GenerateRandom(List<CallNumber> list)
        {
            //Generate 10 random call numbers and add them to the list
            Random rnd = new Random();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            for (int i = 1; i <= 10; i++)
            {
                list.Add(new CallNumber(Convert.ToString(i), 
                    rnd.Next(999).ToString().PadLeft(3, '0') + "." +
                    rnd.Next(99).ToString().PadLeft(2, '0') + " " +
                    alphabet.ElementAt(rnd.Next(26)).ToString() +
                    alphabet.ElementAt(rnd.Next(26)).ToString() +
                    alphabet.ElementAt(rnd.Next(26)).ToString()));
            }

            //Print the index numbers
            foreach (var item in list)
            {
                tbIndex.Text += "\n  " + item.Index + ".";
            }
        }

        private void PrintList(List<CallNumber> list)
        {
            textblock.Text = "";
            //Print the current version of the list
            foreach (var item in list)
            {
                textblock.Text += "\n  " + item.Value;
            }
        }
        private void CheckList(List<CallNumber> list)
        {
            //Check if the list is in numerical and alphabetical order
            List<CallNumber> sortedList = new List<CallNumber>(list);
            sortedList.Sort();

            if (list.SequenceEqual(sortedList) == true)
            {
                MessageBox.Show("YOU WIN!");
            }
        }

        public void ReplacingBooks_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //Makes the window draggable while holding down the mouse
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void ButtonMainMenu_Click(object sender, RoutedEventArgs e)
        {
            //User selected Main Menu
            MainWindow obj = new MainWindow();
            //Open the selected window
            obj.Show();
            //Close the current window
            Close();
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            //User selected Reset
            //This will result in a new set of 10 random call numbers being generated
            ReplacingBooks obj = new ReplacingBooks();
            //Open a new instance of the window
            obj.Show();
            //Close the current window
            Close();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //User selected Exit
            Close();
        }
    }
}
