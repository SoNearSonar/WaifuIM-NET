using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding ia list of versatile and nsfw tags
    /// </summary>
    public class WaifuFullTagList
    {
        /// <summary>
        /// The list of tags that are versatile and/or safe for work
        /// </summary>
        [JsonProperty("versatile")]
        public WaifuImageTag[] VersatileTags { get; set; }

        /// <summary>
        /// The list of tags that are not safe for work
        /// </summary>
        [JsonProperty("nsfw")] 
        public WaifuImageTag[] NsfwTags { get; set; }
    }
}
