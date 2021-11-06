using System;
using System.ComponentModel.DataAnnotations;

namespace Second.ViewModels
{
    public class HorseViewModel
    {
        [Key]
        public Guid VmId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}