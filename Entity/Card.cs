using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace generate_card.Entity
{
    [Table("Card")]
    public class Card : BaseEntity
    {
        [Key] 
        public int Id { get; set; }
        
        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }
        
        public DateTime Validate { get; set; }
        
        public int SecurityCode { get; set; }
        
        [ForeignKey("User")]
        public string UserEmail { get; set; }
        public virtual User User { get; set; }
    }
}