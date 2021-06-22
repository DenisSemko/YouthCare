using System;
using System.Collections.Generic;
using System.Text;

namespace CIL.DTOs
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public Guid SportsmanUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
