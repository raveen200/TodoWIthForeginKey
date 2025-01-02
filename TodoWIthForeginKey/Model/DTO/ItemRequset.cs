using System.ComponentModel.DataAnnotations;

namespace TodoWIthForeginKey.Model.DTO
{
    public class ItemRequset
    {
        public int Id { get; set; }
        public string? TaskName { get; set; }
        public int CategoryId { get; set; }
    }
}
