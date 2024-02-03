using System.Runtime.Serialization;

namespace WaifuIM.Web.Models
{
    /// <summary>
    /// A status to represent the result of a API call
    /// </summary>
    public enum WaifuFavoriteStatus
    {
        /// <summary>
        /// Favorite was removed
        /// </summary>
        [EnumMember(Value = "DELETED")] Deleted,

        /// <summary>
        /// Favorite was added
        /// </summary>
        [EnumMember(Value = "INSERTED")] Inserted
    }
}
