using System;
using System.Collections.Generic;
namespace TinyCrm
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public DateTime Created { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string VatNumber { get; private set; }
        public string Phone { get; set; }
        public decimal TotalGross { get; private set; }
        public bool IsActive { get; set; }
        public int Age { get; set; }

        public List<Order> ListOfOrders;



        public Customer()
        {
            ListOfOrders = new List<Order>();
        }

        public Customer(string vatNumber)
        {
            if (!IsValidVat(vatNumber))
            {
                throw new Exception("Invalid VatNumber");
            }
            VatNumber = vatNumber;
            Created = DateTime.Now;
        }


        public bool IsHightValueCustomer()
        {
            return TotalGross > 10000M;
        }
        public void SetPhone(string phone)
        {
            Phone = phone;
        }

        public bool IsValidVat(string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            str = str.Trim();
            int i = 0;

            if (str.Length == 9 && int.TryParse(str, out i))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsValidEmail(String str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                str = str.Trim();
                if (str.Contains("@") && str.Contains(".com") && str.Contains(".gr"))
                {
                    return true;
                }

            }
            return false;
        }
    }
}
