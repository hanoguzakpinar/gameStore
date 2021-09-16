using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Publisher
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}