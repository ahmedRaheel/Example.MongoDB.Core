using MongoDB.Bson;
using System;

namespace Example.Domain.Common
{
    public abstract class BaseEntity : IBaseEntity
    {
        #region Properties
        
        public ObjectId Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate => Id.CreationTime;
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        #endregion

        #region Constructor
        public BaseEntity()
        {

        } 
        #endregion
    }
}
