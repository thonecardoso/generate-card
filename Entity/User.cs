using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace generate_card.Entity
{
    [Table("User")]
    public class User : BaseEntity
    { 
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }
        
        [Column(TypeName = "varchar(255)")]
        public string DocumentIdentificationNumber { get; set; }
       
        [Column(TypeName = "varchar(255)")]
        public string Email { get; set; }
        
        public virtual ICollection<Card> Cards { get; set; }

    }
}