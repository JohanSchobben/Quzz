using Api.Dto;
using AutoMapper;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizzesController : Controller
    {
        private IQuizBuilderService _quizbuilderService;
        private IMapper _mapper;

        public QuizzesController(IQuizBuilderService quizBuilderService, IMapper mapper) 
        {
            _mapper = mapper;
            _quizbuilderService = quizBuilderService;
        }

        [HttpGet]
        public IActionResult ListAllQuizzes()
        {
            var response = _quizbuilderService.GetQuizzes().Select(x => _mapper.Map<QuizDto>(x)).ToList();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetQuiz(Guid id) 
        {
            var response = _quizbuilderService.GetQuizById(id);
            
            if(response == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<QuizDto>(response));
        }

        [HttpPost]
        public IActionResult Post(QuizDto quizDto) 
        {
            var quiz = _mapper.Map<Quiz>(quizDto);
            var updatedQuiz = _quizbuilderService.Save(quiz);
            var response = _mapper.Map<QuizDto>(updatedQuiz);
            return Created(new Uri(string.Format("/api/quizzes/{0}", response.Id)), response); 
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id) 
        {
            _quizbuilderService.DeleteQuiz(id);
            return NoContent();

        }

        [HttpPost]
        [Route("{quizId}/rounds")]
        public IActionResult AddRound(Guid quizId, RoundDto roundDto)
        {
            var round = _mapper.Map<Round>(roundDto);
            var newRound = _quizbuilderService.AddRoundToQuiz(quizId, round);
            return Created(new Uri(string.Format("/api/quizzes/{0}/rounds/{1}", quizId, newRound.Id)), _mapper.Map<RoundDto>(round));
        }

        [HttpDelete]
        [Route("{quizId}/rounds/{roundId}")]
        public IActionResult DeleteRound (Guid quizId, Guid roundId)
        {
            var quiz = _quizbuilderService.GetQuizById(quizId);
            var hasRound = quiz.Rounds.Any(x => x.Id == roundId);
            if (!hasRound) {
                return BadRequest(new { message = "round is not current quiz" });
            }
            _quizbuilderService.DeleteRound(roundId);
            return NoContent();
        }

        [HttpPost]
        [Route("{quizId}/rounds/{roundId}/questions")]
        public IActionResult AddQuestion(Guid quizId, Guid roundId, QuestionDto questionDto)
        {
            var quiz = _quizbuilderService.GetQuizById(quizId);
            var question = _mapper.Map<Question>(questionDto);
            var hasRound = quiz.Rounds.Any(x => x.Id == roundId);
            if (!hasRound)
            {
                return BadRequest(new { message = "round is not current quiz" });
            }
            var savedQuiz = _quizbuilderService.AddQuestion(roundId, question);
            return Created("", savedQuiz);
        }
    }
}
