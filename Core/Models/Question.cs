using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public  string Asking { get; set; }
        public int AnswerIndex { get; set; }
        public string Answers { get; set; }
        public Round Round { get; set; }
        public Guid RoundId { get; set; }
    }
}
