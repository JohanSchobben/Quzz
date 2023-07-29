using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
    public class QuizDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public IList<RoundDto> Rounds { get; set; }
    }
}
