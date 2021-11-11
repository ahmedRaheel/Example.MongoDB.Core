using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
namespace Example.Domain.Common
{
    public interface IBaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get;  }
        string LastModifiedBy { get; set; }
        DateTime LastModifiedDate { get; set; }
    }
}
