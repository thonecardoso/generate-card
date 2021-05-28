using System;
using System.ComponentModel.DataAnnotations;

namespace generate_card.Entity
{
    public interface IBaseEntity
    {
            [Key] int Id { get; set; }
        
            DateTime? CreatedDate { get; set; }
            DateTime? LastModifiedDate { get; set; }
    }
}