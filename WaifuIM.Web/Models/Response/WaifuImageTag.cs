using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    /// An object holding information a tag
    /// </summary>
    public class WaifuImageTag
    {
        /// <summary>
        ///   An ID for the tag
        /// </summary>
        [JsonProperty("tag_id")]
        public uint TagId { get; set; }

        /// <summary>
        ///   A name for the tag
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///   A description for the tag
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///   A value representing if the tag is considered not safe for work
        /// </summary>
        [JsonProperty("is_nsfw")]
        public bool IsNsfw { get; set; }
    }
}
