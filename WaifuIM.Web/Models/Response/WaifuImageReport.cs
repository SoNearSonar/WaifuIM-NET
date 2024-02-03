using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    /// An object holding report information for an image
    /// </summary>
    public class WaifuImageReport
    {
        /// <summary>
        /// The ID of the image that was reported
        /// </summary>
        [JsonProperty("image_id")]
        public uint ImageId { get; set; }

        /// <summary>
        /// The ID of the person who reported the image
        /// </summary>
        [JsonProperty("author_id")]
        public ulong AuthorId { get; set; }

        /// <summary>
        /// The reason for the image being reported
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// If the report was already created for the given image
        /// </summary>
        [JsonProperty("existed")]
        public bool Existed { get; set; }
    }
}
