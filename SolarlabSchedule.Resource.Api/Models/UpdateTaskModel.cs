namespace SolarlabSchedule.Resource.Api.Models
{
    public class UpdateTaskModel
    {
        public int IdPreviousTask { get; set; }
        public string NameTask { get; set; }
        public string? Description { get; set; }
    }
}