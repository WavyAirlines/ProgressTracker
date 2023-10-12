namespace ProgressTracker.Models
{
    public class Movement
    {
        public int MovementId {  get; set; }
        public string Name { get; set; }    
        public decimal Reps {  get; set; }
        public int CategoryId  { get; set; }
        //parent reference - connection to the 1 category that a soecific product belongs to 
        public Category? Category { get; set; }
        //child reference
        public List<MovementItem>? MovementItems { get; set; }
        public List <TrainingDetail>? TrainingDetails { get; set; }
    }
}
