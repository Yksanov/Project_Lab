using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Math
    {
        [Required]
        public int a { get; set; }
        [Required]
        public int b { get; set; }
    }
}
