namespace ProgressTracker.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //child reference to movements (1 category / many movements)
        public List<Movement>? Movements { get; set; }
    }
}
