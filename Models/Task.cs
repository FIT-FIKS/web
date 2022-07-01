
namespace Fiks.Models
{
    public class Task
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int MaxScore { get; set; }

        public File ReferenceSolution { get; set; }

        public string Title { get; set; }

        public TaskType Type { get; set; }
    }

    public enum TaskType { 
        // todo: task types
    }
}
