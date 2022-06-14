using Jokes.Models;
using Jokes.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Jokes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokeController : ControllerBase
    {
        private JokesContext context;
        public JokeController(JokesContext dbContext)
        {
            context = dbContext;
        }
        
        [HttpGet]
        [Route("read")]
        public List<JokeViewModel> Get()
        {
            return context.Jokes.Select(x => new JokeViewModel(x)).ToList();
        }
        
        [HttpGet]
        [Route("read/{id}")]
        public JokeViewModel Get(int id)
        {
            return context.Jokes
                .Where(x => x.JokeId == id)
                .Select(x => new JokeViewModel(x)).FirstOrDefault();
        }
        
        [HttpPost]
        [Route("create")]
        public IActionResult Post(Joke model)
        {
            var joke = new Joke();
            joke.JokeQuestion = model.JokeQuestion;
            joke.JokeAnswer = model.JokeAnswer;
            context.Jokes.Add(joke);
            context.SaveChanges();
            return Ok();
        }
        
        [HttpPut]
        [Route("update")]
        public IActionResult Put(Joke model)
        {
            var joke = context.Jokes.Where(x => x.JokeId == model.JokeId).FirstOrDefault();
            if (joke == null)
            {
                return NotFound();
            }
            else
            {
                joke.JokeQuestion = model.JokeQuestion;
                joke.JokeAnswer = model.JokeAnswer;
                context.SaveChanges();
                return Ok(joke);
            }
        }
        
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = context.Jokes.Where(x => x.JokeId == id).FirstOrDefault();
            if (entity == null)
            {
                return NotFound();
            }
            context.Jokes.Remove(entity);
            context.SaveChanges();
            return Ok();
        }
    }
}
