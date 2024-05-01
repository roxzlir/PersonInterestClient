using System.ComponentModel.DataAnnotations;

namespace PersonInterestClient.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [StringLength(60)]
        public string PersonName { get; set; }
        [StringLength(120)]
        public string PersonPhone { get; set; }
    }
}
