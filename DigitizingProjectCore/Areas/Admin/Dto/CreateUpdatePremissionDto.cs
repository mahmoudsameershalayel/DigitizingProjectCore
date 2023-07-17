using DigitizingProjectCore.Models;

namespace DigitizingProjectCore.Areas.Admin.Dto
{
    public class CreateUpdatePremissionDto
    {
        public List<Link> Links { get; set; }
        public long[] LinkIds { get; set; }
    }
}
