using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding the status of a favorite API call
    /// </summary>
    internal class WaifuFavorite
    {
        /// <summary>
        /// The result of the favorite API call
        /// </summary>
        /// <value><see cref="Enums.FavoriteStatus"/></value>
        [JsonProperty("state")]
        public WaifuFavoriteStatus FavoriteStatus { get; set; }
    }
}
