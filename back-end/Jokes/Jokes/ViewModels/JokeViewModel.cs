using Jokes.Models;

namespace Jokes.ViewModels
{
    public class JokeViewModel
    {
        public JokeViewModel()
        {

        }

        public JokeViewModel(Joke j)
        {
            JokeId = j.JokeId;
            JokeQuestion = j.JokeQuestion;
            JokeAnswer = j.JokeAnswer;
        }

        public int JokeId { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
    }
}
