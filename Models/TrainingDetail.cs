using System.ComponentModel.DataAnnotations;

namespace ProgressTracker.Models
{
    public class TrainingDetail
    {
        public int TrainingDetailId { get; set; }

        [Required]
        public int Reps { get; set; }
        [Required]
        public int TrainingId { get; set; }

        [Required]
        public int MovementId { get; set; }

        public Movement? Movement { get; set; }
        public Training? Training { get; set; } 
    }
}
