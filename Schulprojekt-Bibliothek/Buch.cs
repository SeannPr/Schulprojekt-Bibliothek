using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulprojekt_Bibliothek
{
    public class Buch
    {
        public int id { get; set; }     // Primary Key
        public string Bücher { get; set; }  // Identifier for the book
        public string Autor { get; set; }   // Author of the book
        public string Titel { get; set; }   // Title of the book
        public int Seiten { get; set; }     // Number of pages in the book
    }
}
