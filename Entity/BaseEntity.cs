using System;

namespace generate_card.Entity
{
    public abstract class BaseEntity : IBaseEntity
    {
        protected BaseEntity()
        {
            if (CreatedDate == null)
                CreatedDate = DateTime.Now;
            LastModifiedDate = DateTime.Now;
        }
        
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}