using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleMVCApp.Calculator.Test
{
    [TestClass]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initilize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void Sum()
        {
            // Arrage
            var x = 2;
            var y = 2;

            // Act
            var result = _calculator.Sum(x, y);

            // Assert
            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Subtract()
        {
            // Arrage
            var x = 2;
            var y = 2;
            Employee emp = new EmployeeBuilder().WithFirstName("Erwin")
                                    .WithLastName("Staal");
            // Act
            var result = _calculator.Subtract(x, y);

            // Assert
            Assert.AreEqual(0, result);
        }
    }

    public class EmployeeBuilder
    {
        private int _id = 1;
        private string _firstname = "first";
        private string _lastname = "last";
        private DateTime _birthdate = DateTime.Today;
        private string _street = "street";

        public Employee Build()
        {
            return new Employee(_id, _firstname, _lastname, _birthdate, _street);
        }

        public EmployeeBuilder WithFirstName(string firstname)
        {
            _firstname = firstname;
            return this;
        }

        public EmployeeBuilder WithLastName(string lastname)
        {
            _lastname = lastname;
            return this;
        }

        public EmployeeBuilder WithBirthDate(DateTime birthdate)
        {
            _birthdate = birthdate;
            return this;
        }

        public EmployeeBuilder WithStreet(string street)
        {
            _street = street;
            return this;
        }

        public static implicit operator Employee(EmployeeBuilder instance)
        {
            return instance.Build();
        }
    }

    public class Employee
    {
        public Employee(int id, string firstname, string lastname, DateTime birthdate, string street)
        {
            ID = id;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
            Street = street;
        }

        public int ID { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public string Street { get; private set; }

        public string getFullName()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}

