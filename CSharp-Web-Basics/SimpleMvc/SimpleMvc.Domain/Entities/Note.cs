﻿namespace SimpleMvc.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int OwnerId { get; set; }

        public User Owner { get; set; }
    }
}