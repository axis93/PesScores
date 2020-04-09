using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ClassLibrary;
using DataLayer;

namespace PesScores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Background = Brushes.CornflowerBlue;
             InitializeComponent();
        }

        private bool valid = false;

        private void btn_AddDate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(txt_date.Text == "")
                {
                    throw new System.ArgumentException("Field cannot be blank!", "Date");
                }
                else if(txt_date.Text == "dd/mm/yy")
                {
                    throw new System.ArgumentException("Field must be modified, please enter a valid date", "Date");
                }
                SingletonResults saver = SingletonResults.Instance;
                
                saver.saveDate(txt_date.Text);
                MessageBox.Show("Date successfully added");
                valid = true;
                // Add the date to the file
                /*
                 Put something here
                 */
                 
            }catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Roy_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                // Create a method that returns true or false or something else that checks that a player has been already
                // added to the program. If there is no player added, than create one, otherwise retrieve that object
                // and update its data
                if(txt_roy.Text == (""))
                {
                    throw new System.ArgumentException("Field cannot be blank", "Roy goals");
                }else if (txt_roy.Text.All(char.IsLetter))
                {
                    throw new System.ArgumentException("Filed must be a number", "Roy goals");
                }
                else if(Int32.Parse(txt_roy.Text) < 0)
                {
                    throw new System.ArgumentException("Field must be a number bigger than 0", "Roy goals");
                }

               
                MessageBox.Show("Roy goals have been added!");
                valid = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            
            //Roy.addGaols(Int32.Parse(txt_roy.Text));
            // Player Roy 
        }


        private void btn_Spuk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create a method that returns true or false or something else that checks that a player has been already
                // added to the program. If there is no player added, than create one, otherwise retrieve that object
                // and update its data
                if (txt_spuk.Text == (""))
                {
                    throw new System.ArgumentException("Field cannot be blank", "Spuk goals");
                }
                else if (txt_spuk.Text.All(char.IsLetter))
                {
                    throw new System.ArgumentException("Filed must be a number", "Spuk goals");
                }
                else if (Int32.Parse(txt_roy.Text) < 0)
                {
                    throw new System.ArgumentException("Field must be a number bigger than 0", "Spuk goals");
                }

                MessageBox.Show("Spuk goals have been added!");
                valid = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            // Convention to call the player Roy as it is the name I am going to use
            // Please change it as you wish
            Player Roy = new Player();
            // This will initialize the name of the player according to the content of the label that user puts
            Roy.Name = lbl_player1.Content.ToString();
            int goalRoy = Int32.Parse(txt_roy.Text);
            Roy.addGaols(goalRoy);
            Player Spuk = new Player();
            Spuk.Name = lbl_player2.Content.ToString();
            int goalSpuk = Int32.Parse(txt_spuk.Text);
            Roy.goalsTaken(goalSpuk, Roy);
            Spuk.addGaols(goalSpuk);
            Spuk.goalsTaken(goalRoy, Spuk);

            
            Program pr = new Program();
            pr.checkWinner(goalRoy, goalSpuk, Roy, Spuk);
            Roy.Points = Roy.calculatePoints(Roy.Win, Roy.Draw);
            Spuk.Points = Spuk.calculatePoints(Spuk.Win, Spuk.Draw);



        }
        private void btn_DisplayBoard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_DisplayResults_Click(object sender, RoutedEventArgs e)
        {
            SingletonResults loader = SingletonResults.Instance;
            
            txtOutput.Text = loader.loadResult();
        }

        private void btn_saveResult_Click(object sender, RoutedEventArgs e)
        {

            string result = "";
            
            result += "Roy " + Int32.Parse(txt_roy.Text) + " - " + Int32.Parse(txt_spuk.Text) + " Spuk";
            SingletonResults saver = SingletonResults.Instance;
            saver.saveResult(result);
            /*if(sender == btn_Spuk && sender == btn_AddDate && sender == btn_Roy)
            {
                btn_saveResult.Visibility = Visibility.Visible;

            }
            else
            {
                btn_saveResult.Visibility = Visibility.Hidden;
            }*/
        }

        private void txt_roy_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

       
    }
}
