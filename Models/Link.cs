using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonInterestClient.Models
{
    public class Link
    {
        [Key]
        public int LinkId { get; set; }
        [ForeignKey("Person")]
        public int FkPersonId { get; set; }
        //public Person? Person { get; set; }
        [ForeignKey("Interest")]
        public int FkInterestId { get; set; }
        //public Interest? Interest { get; set; }
        [StringLength(200)]
        public string LinkAddress { get; set; }
    }
}
