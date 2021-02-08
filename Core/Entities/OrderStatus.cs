using System.Runtime.Serialization;

namespace Core.Entities
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Pending")]
        Pending,
        [EnumMember(Value = "Confirmed")]
        Confirmed,
        [EnumMember(Value = "Failed")]
        Failed
    }
}