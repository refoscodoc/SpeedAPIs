using System;

namespace First.Models
{
    public class GuitarModel
    {
        public Guid Id { get; set; } 
        public string Brand { get; set; }
        public float Price { get; set; }
        public string Wood { get; set; }
        public int Year { get; set; }
    }
}