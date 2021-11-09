using Third.Models.Interfaces;

namespace Third.Models
{
    public class Pet : IDog, IBird, IFish
    {
        public int Id { get; set; }
        public int Species { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}