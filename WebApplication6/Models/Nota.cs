using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Nota
    {
        public int idnota { get; set; }
        public string Content { get; set; }
    
        public Nota( string cont, int id)
        {
            idnota = id;
            Content = cont;
        }
    }
}