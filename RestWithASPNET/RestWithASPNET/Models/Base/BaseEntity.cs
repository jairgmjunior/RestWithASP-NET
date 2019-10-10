using System.Runtime.Serialization;

namespace RestWithASPNET.Models.Base
{
    [DataContract]
    public class BaseEntity
    {
        public long Id { get; set; }
    }
}
