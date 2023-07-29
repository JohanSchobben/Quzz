using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IQuizBuilderService
    {
        Quiz Save(Quiz quiz);
        IEnumerable<Quiz> GetQuizzes();
        Quiz GetQuizById(Guid id);
        Round AddRoundToQuiz(Guid quizId, Round round);
        void DeleteRound(Guid roundId);
        void DeleteQuiz(Guid quizId);
        Question AddQuestion(Guid roundId, Question question);
        void DeleteQuestion(Guid questionId);


    }
}
