using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;
        public string FirstName 
        {
            get 
            {
                return firstName;
            } 
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("First name cannot conrain fewer than 3 symbols!");
                }
                firstName = value;
            }
        }

        public string LastName 
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot conrain fewer than 3 symbols!");
                }
                lastName = value;
            }
        }

        public int Age 
        {
            get
            {
                return age;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                age = value;
            }
        }

        public decimal Salary 
        {
            get
            {
                return salary;
            }
            private set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                salary = value;
            }
        }
        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public Person(string firstName , string lastName , int age , decimal salary)
            : this(firstName, lastName, age)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (Age < 30)
            {
                Salary += Salary * (percentage / 2) / 100;
            }
            else
            {
                Salary += Salary * percentage / 100;
            }
        }


    }
}
