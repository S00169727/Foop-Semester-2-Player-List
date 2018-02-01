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

namespace Player_List
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Fields
        private Random _dateGen = new Random();
        private const int _startAge = 8;
        private const int _endAge = 18;

        //Creating a list of player objects
        List<Player> playersList = new List<Player>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            //Filling the list with player objects
            playersList.Add(new Player() { Name = "Mike Smith", DOB = GetRandomDate(_startAge, _endAge, _dateGen) });
            playersList.Add(new Player() { Name = "Sue Smith", DOB = GetRandomDate(_startAge, _endAge, _dateGen) });
            playersList.Add(new Player() { Name = "John Smith", DOB = GetRandomDate(_startAge, _endAge, _dateGen) });
            playersList.Add(new Player() { Name = "Joanne Smith", DOB = GetRandomDate(_startAge, _endAge, _dateGen) });

            //Calculating the age for every player in the list
            foreach (Player player in playersList)
            {
                player.CalculateAge();
                player.CalculateAgeGroup();
            }
            

            //Setting the list box to display the player objects once the application loads
            listBoxPlayerList.ItemsSource = playersList;
        }

        
        //Method to return a random date of birth between 18 and 8 years ago
        static DateTime GetRandomDate(int _startAgeIn, int _endAgeIn, Random _dateGenIn)
        {
            //Get start date and end date
            DateTime startDate = DateTime.Now.AddYears(-_startAgeIn); //31/01/2008
            DateTime endDate = DateTime.Now.AddYears(-_endAgeIn); //31/01/2000

            //Get a randomnumber of days in that range
            TimeSpan range = startDate - endDate;

            //Grab the total number of the days from the year range
            double daysInRange = range.TotalDays;

            int randomDays = _dateGenIn.Next(0,(int)daysInRange);

            //Getting a new random date
            DateTime newRandomDate = endDate.AddDays(randomDays);

            return newRandomDate;
        }


        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            //Checking to see if the name and datepicker have a value inside of them
            if (txtBoxName != null && datePicker1 != null)
            {
                //If they have data in them then add a new player object to the list and display it
                playersList.Add(new Player() { Name = txtBoxName.Text, DOB = DateTime.ParseExact(datePicker1.SelectedDate.Value.ToString(),"dd/MM/yyyy", null) });
            }
            //Make the listbox display whatever is in it at the time before the button press
            else
            {
                listBoxPlayerList.ItemsSource = null;
                listBoxPlayerList.ItemsSource = playersList;
            }

            //Keeping the orignal list if nothing is put into the boxes originally
            listBoxPlayerList.ItemsSource = null;
            listBoxPlayerList.ItemsSource = playersList;
        }

        private void BtnSaveContent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLoadContent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
