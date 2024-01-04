
namespace ReviewService.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public required Reviewer Reviewer { get; set; }
        public Pokemon Pokemon { get; set; }
        public int Rating { get; internal set; }

      
    }
}
