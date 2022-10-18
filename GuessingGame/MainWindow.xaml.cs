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

namespace GuessingGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int resultInt = 0;
        int guessesNumber = 0;
        string guessesList = "";
        
        private readonly Random random;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();
            buttonGuess.IsEnabled = false;
            textBoxGuess.IsEnabled = false;
        }

        private void buttonStart_Click(object sender, RoutedEventArgs e) //TODO: How to name the controls? (capital B?)
        {
            resultInt = random.Next(0, int.Parse(comboBoxUpperLimit.Text) + 1);
            textBlockTest.Text = resultInt.ToString();
            buttonGuess.IsEnabled = true;
            buttonStart.IsEnabled = false;
            textBoxGuess.IsEnabled = true;
        }

        private void buttonGuess_Click(object sender, RoutedEventArgs e)
        {
            bool success = int.TryParse(textBoxGuess.Text, out int guessInt);

            if (success)
            {
                textBlockMessage.Text = guessInt.ToString();
                guessesNumber++;
                guessesList += guessInt.ToString() + "; ";

                if (guessInt > resultInt)
                {
                    textBlockMessage.Text = $"The number you are looking for is smaller than {guessInt}!";
                    textBoxGuess.Text = " ";
                }
                else if (guessInt < resultInt)
                {
                    textBlockMessage.Text = $"The number you are looking for is bigger than {guessInt}!";
                    textBoxGuess.Text = " ";
                }
                else if (guessInt == resultInt)
                {
                    textBlockMessage.Text = "BINGO!";
                    guessesList = guessesList.Remove(guessesList.Length - 2, 2); //TODO: Why once guesseNumber++; and once guessesList = guessesList...;?
                    MessageBox.Show($"YOU FOUND THE NUMBER!" + Environment.NewLine + $"The guessed number was {resultInt}. You needed {guessesNumber} tips." + Environment.NewLine + $"Your tips were: {guessesList}"); //TODO: How to solve line breaking?
                    guessesNumber = 0; //TODO: Second usage - maybe some initialisation method?
                    guessesList = "";
                    textBoxGuess.Text = " ";
                    textBlockMessage.Text = "Choose the range and press START to generate a new number";
                    buttonGuess.IsEnabled = false;
                    buttonStart.IsEnabled = true;
                    textBoxGuess.IsEnabled = false;
                }
            }
            else
            {
                textBlockMessage.Text = "This is not the correct input";
            }
        }
    }
}
//TODO: Is it possible to control position of the cursor? After Pressing GUESS button, cursor jumps in textbox.