using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    public partial class CustomerContract
    {

        public CustomerContract()
        {

        }
        #region Private Members
        private int id;
        private string firstName;
        private string lastName;
        private string birthDate;
        private string address;
        private string city;
        private string email;
        private string gender;
        private string phone;
        private string country;
        private int? balance;
        private string password;
        public DateTime SystemDate;
        public string? Status;
        public DateTime LastUpdateDate;
        private Int64 tckn;
        #endregion
        #region Public Members
        public String Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                }
            }
        }
        public Int64 TCKN
        {
            get { return tckn; }
            set
            {
                if (tckn != value)
                {
                    tckn = value;
                }
            }
        }
        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                }
            }
        }
        public String FirstName
        {
            get { return firstName; }
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                }
            }
        }
        public String LastName
        {
            get { return lastName; }
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                }
            }
        }
        public String BirthDate
        {
            get { return birthDate; }
            set
            {
                if (birthDate != value)
                {
                    birthDate = value;
                }
            }
        }
        public String Address
        {
            get { return address; }
            set
            {
                if (address != value)
                {
                    address = value;
                }
            }
        }
        public String City
        {
            get { return city; }
            set
            {
                if (city != value)
                {
                    city = value;
                }
            }
        }
        public String Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                }
            }
        }
        public String Gender
        {
            get { return gender; }
            set
            {
                if (gender != value)
                {
                    gender = value;
                }
            }
        }
        public String Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    phone = value;
                }
            }
        }
        public String Country
        {
            get { return country; }
            set
            {
                if (country != value)
                {
                    country = value;
                }
            }
        }
        public Int32? Balance
        {
            get { return balance; }
            set
            {
                if (balance != value)
                {
                    balance = value;
                }
            }
        }


        #endregion

    }
}
