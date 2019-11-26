using System;

namespace DTO
{
    public class CommentDTO
    {
        public string Content { get; set; }
        public float Rate { get; set; } 
        public string Avatar { get; set; }
        public DateTime? Date { get; set; }

        public CommentDTO()
        {
        }

        public CommentDTO(string content, float rate, string avatar, DateTime? date)
        {
            Content = content;
            Rate = rate;
            Avatar = avatar;
            Date = date;
        }
    }
}
