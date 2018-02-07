using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player_List
{
    //Player Class
    class Player
    {
        //Enum for age groups
        private enum _AgeGroups { u10, u12, u14, u16, u18};

        //Properties
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public string AgeGroupsOutput { get; set; }

        //Player method sets the age based on todays date minus the random age set
        public void CalculateAge()
        {
            Age = DateTime.Now.Year - DOB.Year;
        }

        //Method to give the players their age group
        public void CalculateAgeGroup()
        {
            if (Age <= 10)
            {
                AgeGroupsOutput = _AgeGroups.u10.ToString();
            }
            else if (Age > 10 && Age <= 12)
            {
                AgeGroupsOutput = _AgeGroups.u12.ToString();
            }
            else if (Age > 12 && Age <= 14)
            {
                AgeGroupsOutput = _AgeGroups.u14.ToString();
            }
            else if (Age > 14 && Age <= 16)
            {
                AgeGroupsOutput = _AgeGroups.u16.ToString();
            }
            else if (Age > 16 && Age <= 18)
            {
                AgeGroupsOutput = _AgeGroups.u18.ToString();
            }
        }
        
        //Overriding the ToString method
        public override string ToString()
        {
            return string.Format($"{Name}, {Age}, {AgeGroupsOutput}");
        }

    }
}
