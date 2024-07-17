using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Annarth.Domain.Entities
{
    public class Company
    {
        /// <summary>
        /// Id Company
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Company Name
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Estado del Registro
        /// </summary>
        public bool State { get; set; }
    }
}
