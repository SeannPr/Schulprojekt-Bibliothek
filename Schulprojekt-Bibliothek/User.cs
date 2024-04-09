using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulprojekt_Bibliothek
{
    public class User
    {
        public int id { get; set; }          // Primary Key
        public string Vorname { get; set; }  // First name
        public string Nachname { get; set; } // Last name
        public string Email { get; set; }    // Email address
        public int Tel { get; set; }         // Telephone number
        public string Stadt { get; set; }    // City
        public int Userld { get; set; }      // Foreign Key
        public int Pin { get; set; }         // Personal Identification Number
    }
}
