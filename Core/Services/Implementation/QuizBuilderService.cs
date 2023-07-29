using Core.Data;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Implementation
{
    public class QuizBuilderService : IQuizBuilderService
    {
        private QuzzDbContext _context;
        public QuizBuilderService(QuzzDbContext context) 
        {
            _context = context;
        }
        public Round AddRoundToQuiz(Guid quizId, Round round)
        {
            round.QuizId = quizId;
            return _context.Rounds.Add(round).Entity;
        }

        public void DeleteQuiz(Guid quizId)
        {
            var quiz = _context.Quizzes.FirstOrDefault(x =>  x.Id == quizId);
            if (quiz != null)
            {
                _context.Quizzes.Remove(quiz);
            }
        }

        public void DeleteRound(Guid roundId)
        {
            var round = _context.Rounds.FirstOrDefault(x => x.Id == roundId);
            if (round != null)
            {
                _context.Rounds.Remove(round);
            }
        }

        public IEnumerable<Quiz> GetQuizzes()
        {
            return _context.Quizzes;
        }

        public Quiz GetQuizById(Guid id)
        {
            return _context.Quizzes.FirstOrDefault(x => x.Id == id);
        }

        public Quiz Save(Quiz quiz)
        {
           var savedQuiz = _context.Quizzes.Add(quiz).Entity;
            _context.SaveChanges();
            return savedQuiz;
        }

        public Question AddQuestion(Guid roundId, Question question)
        {
            question.RoundId = roundId;
            var savedQuestion = _context.Questions.Add(question).Entity;
            _context.SaveChanges();
            return savedQuestion;
        }

        public void DeleteQuestion(Guid questionId)
        {
            var question = _context.Questions.FirstOrDefault(x => x.Id == questionId);
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}
