using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Movie
    {
        
        public int MovieId { get; set; }

       
        public string MovieName { get; set; }
        public string Category { get; set; }
        public int Duration { get; set; }

      
        public string Director { get; set; }
    }
}
