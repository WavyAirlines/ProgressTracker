using System.ComponentModel.DataAnnotations;

namespace ProgressTracker.Models
{
    public class Training
    {
        public int TrainingId { get; set; }

        [Display(Name = "Training Start Date")]
        public DateTime TrainingDate { get; set; }

        [Display(Name = "Total Reps")]
        public decimal Reps { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        public string Province { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Postal Code")]

        public string PostalCode { get; set; }

        [Required]
        [MaxLength(15)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]
        [MaxLength(100)]
        public string CategoryId { get; set; }
        //child ref
        public List<TrainingDetail>? TrainingDetails { get; set; }

    }
}
