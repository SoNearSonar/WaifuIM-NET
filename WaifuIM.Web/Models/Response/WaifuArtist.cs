using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding the information for an artist for an image
    /// </summary>
    public class WaifuArtist
    {
        /// <summary>
        ///   The numerical id of the artist
        /// </summary>
        [JsonProperty("artist_id")]
        public uint Id { get; set; }

        /// <summary>
        ///   The name of the artist
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///   The artist's Patreon url
        /// </summary>
        [JsonProperty("patreon")]
        public string PatreonLink { get; set; }

        /// <summary>
        ///   The artist's Pixiv url
        /// </summary>
        [JsonProperty("pixiv")]
        public string PixivLink { get; set; }

        /// <summary>
        ///   The artist's Twitter url
        /// </summary>
        [JsonProperty("twitter")]
        public string TwitterLink { get; set; }

        /// <summary>
        ///   The artist's DeviantArt url
        /// </summary>
        [JsonProperty("deviant_art")]
        public string DeviantArtLink { get; set; }
    }
}
