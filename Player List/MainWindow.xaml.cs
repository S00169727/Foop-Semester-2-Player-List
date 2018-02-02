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
        private static Random _dateGen = new Random();
        private const int _startAge = 8;
        private const int _endAge = 18;

        //Creating a list of player objects
        private List<Player> _playersList = new List<Player>();
        
        //Get start date and end date
        private static DateTime _startDate = DateTime.Now.AddYears(-_startAge); //31/01/2008
        private static DateTime _endDate = DateTime.Now.AddYears(-_endAge); //31/01/2000

        //Get a randomnumber of days in that range
        private TimeSpan _range = _startDate - _endDate;

        public MainWindow()
        {
            InitializeComponent();

            DatePicker datePicker1 = new DatePicker
            {
                SelectedDate = new DateTime(2000, 1, 31),
                DisplayDateStart = new DateTime(2000, 1, 31),
                DisplayDateEnd = new DateTime(2008, 1, 31),
                SelectedDateFormat = DatePickerFormat.Long,
                FirstDayOfWeek = DayOfWeek.Monday
            };
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            //Filling the list with player objects
            _playersList.Add(new Player() { Name = "Mike Smith", DOB = GetRandomDate(_startAge, _endAge, _startDate, _endDate, _dateGen, _range) });
            _playersList.Add(new Player() { Name = "Sue Smith", DOB = GetRandomDate(_startAge, _endAge, _startDate, _endDate, _dateGen, _range) });
            _playersList.Add(new Player() { Name = "John Smith", DOB = GetRandomDate(_startAge, _endAge, _startDate, _endDate, _dateGen, _range) });
            _playersList.Add(new Player() { Name = "Joanne Smith", DOB = GetRandomDate(_startAge, _endAge, _startDate, _endDate, _dateGen, _range) });

            //Calculating the age for every player in the list
            foreach (Player player in _playersList)
            {
                player.CalculateAge();
                player.CalculateAgeGroup();
            }
            

            //Setting the list box to display the player objects once the application loads
            listBoxPlayerList.ItemsSource = _playersList;
        }

        
        //Method to return a random date of birth between 18 and 8 years ago
        static DateTime GetRandomDate(int _startAgeIn, int _endAgeIn, DateTime startDateIn, DateTime endDateIn, Random _dateGenIn, TimeSpan _rangeIn)
        {
            //Grab the total number of the days from the year range
            double daysInRange = _rangeIn.TotalDays;
            int randomDays = _dateGenIn.Next(0,(int)daysInRange);

            //Getting a new random date
            DateTime newRandomDate = endDateIn.AddDays(randomDays);

            return newRandomDate;
        }


        private void BtnAddPlayer_Click(object sender, RoutedEventArgs e)
        {
            //Checking to see if the name and datepicker have a value inside of them
            if (txtBoxName != null && datePicker1 != null)
            {
                //Adding a new player to the list based on the name input and the date picker selection
                _playersList.Add(new Player() { Name = txtBoxName.Text, DOB = datePicker1.SelectedDate.Value });

                txtBoxName.Clear();
            }
            else
            {
                //Make the listbox display whatever is in it at the time before the button press
                listBoxPlayerList.ItemsSource = null;
                listBoxPlayerList.ItemsSource = _playersList;
            }

            //Keeping the orignal list if nothing is put into the boxes originally
            listBoxPlayerList.ItemsSource = null;
            listBoxPlayerList.ItemsSource = _playersList;
        }

        private void BtnSaveContent_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnLoadContent_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
