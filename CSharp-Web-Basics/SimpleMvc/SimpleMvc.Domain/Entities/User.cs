using System.Collections.Generic;

namespace SimpleMvc.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public IList<Note> Notes { get; set; } = new List<Note>();
    }
}