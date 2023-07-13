using System.ComponentModel.DataAnnotations.Schema;

namespace DigitizingProjectCore.Models
{
    public class SolutionProducts
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
        public int? SolutionId { get; set; }
        public Solution Solution { get; set; }
        public int? SortId { get; set; }
    }
}
