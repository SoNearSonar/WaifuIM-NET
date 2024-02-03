using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding favorite information for favorites
    /// </summary>
    public class FavoriteSettings
    {
        /// <summary>
        ///   The user ID to modify favorites for
        /// </summary>
        /// 
        [JsonProperty("user_id")]
        public ulong UserId { get; set; }

        /// <summary>
        ///   The image ID to modify favorites for a user
        /// </summary>
        /// 
        [JsonProperty("image_id")]
        public ulong ImageId { get; set; }
    }
}
