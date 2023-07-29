using Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
    public class RoundDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public RoundType Type { get; set; }
        public IList<QuestionDto> Questions { get; set; }
    }
}
