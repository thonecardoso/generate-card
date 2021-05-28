using System;

namespace generate_card.Entity
{
    public interface IBaseEntity
    {
            DateTime? CreatedDate { get; set; }
            DateTime? LastModifiedDate { get; set; }
    }
}