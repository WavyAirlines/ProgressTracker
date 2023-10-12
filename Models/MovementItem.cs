using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;

namespace ProgressTracker.Models
{
    public class MovementItem
    {


        public int MovementItemId { get; set; }

        [Required]
        public int Reps { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int MovementId { get; set; }

        //parent ref
        public Movement? Movement { get; set; }
    }
}
