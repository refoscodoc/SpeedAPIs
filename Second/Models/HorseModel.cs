using System;
using Second.ViewModels;

namespace Second.Models
{
    public class HorseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Trainer { get; set; }
        public string Owner { get; set; }
        public float StartingPrice { get; set; }
        
        public Guid HorsesViewmodelsId { get; set; }
        public HorseViewModel HorsesViewmodels { get; set; }
    }
}