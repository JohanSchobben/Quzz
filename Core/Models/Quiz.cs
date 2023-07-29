using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Quiz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Round> Rounds { get; } = new List<Round>();
    }
}
