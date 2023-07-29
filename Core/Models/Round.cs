using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Round
    {
        public Guid Id { get; set; }
        public int Order { get; set; }
        public int name { get; set; }
        public RoundType Type { get; set; }

        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } = null;
        public ICollection<Question> Questions { get; } = new List<Question>();
    }
}
