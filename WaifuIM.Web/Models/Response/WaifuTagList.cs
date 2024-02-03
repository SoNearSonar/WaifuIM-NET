using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding a list of versatile and nsfw tag names
    /// </summary>
    public class WaifuTagList
    {
        /// <summary>
        /// The list of tag names that are versatile and/or safe for work
        /// </summary>
        [JsonProperty("versatile")] 
        public WaifuTag[] VersatileTags { get; set; }

        /// <summary>
        /// The list of tag names that are not safe for work
        /// </summary>
        [JsonProperty("nsfw")]
        public WaifuTag[] NsfwTags { get; set; }
    }
}
