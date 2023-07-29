using Api.Validation;
using Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Api.Dto
{
    public class QuestionDto
    {
        public string Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Asking { get; set; }
        [Required]
        [ListItemSize(50, ErrorMessage = "answer.size")]
        public IList<string> Answers { get; set; }
        [Required]
        [IsInOther("Answers")]
        public string CorrectAnswer { get; set; }

    }
}
