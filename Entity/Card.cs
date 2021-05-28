using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace generate_card.Entity
{
    [Table("Card")]
    public class Card : BaseEntity
    {
        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }
        
        public DateTime Validate { get; set; }
        
        public int SecurityCode { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}