using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulprojekt_Bibliothek
{
    public class Ausleihungen
    {
        public int id { get; set; }             // Primary Key
        public int Userld { get; set; }         // Foreign Key
        public User User { get; set; }          // Navigation property to User
        public string Buch { get; set; }        // Title of the book borrowed
        public int AusleihDatum { get; set; }   // Date when the book was borrowed
        public int AbgabeDatum { get; set; }    // Date when the book is due to be returned
    }

}
