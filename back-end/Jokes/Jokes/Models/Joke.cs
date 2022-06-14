using System;
using System.Collections.Generic;

#nullable disable

namespace Jokes.Models
{
    public partial class Joke
    {
        public int JokeId { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
    }
}
