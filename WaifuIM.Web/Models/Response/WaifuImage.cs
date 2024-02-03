using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding information of an image
    /// </summary>
    public class WaifuImage
    {
        /// <summary>
        ///   The signature of the image
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        ///   The image file extension of the image
        /// </summary>
        [JsonProperty("extension")]
        public string Extension { get; set; }

        /// <summary>
        ///   The image ID of the image
        /// </summary>
        [JsonProperty("image_id")]
        public uint ImageId { get; set; }

        /// <summary>
        ///   The number of users that favorited the image
        /// </summary>
        [JsonProperty("favourites")]
        public uint Favourites { get; set; }

        /// <summary>
        ///   The main color on the image
        /// </summary>
        [JsonProperty("dominant_color")]
        public string DominantColor { get; set; }

        /// <summary>
        ///   The source url for the image
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }

        /// <summary>
        ///   The time the image was uploaded at
        /// </summary>
        [JsonProperty("uploaded_at")]
        public string UploadedAt { get; set; }

        /// <summary>
        ///   The time the image was liked at
        /// </summary>
        [JsonProperty("liked_at")]
        public string LikedAt { get; set; }

        /// <summary>
        ///   If the image is not safe for work
        /// </summary>
        [JsonProperty("is_nsfw")]
        public bool IsNsfw { get; set; }

        /// <summary>
        ///   The width of an image
        /// </summary>
        [JsonProperty("width")]
        public uint Width { get; set; }

        /// <summary>
        ///   The size in bytes for an image
        /// </summary>
        [JsonProperty("byte_size")]
        public ulong ByteSize { get; set; }

        /// <summary>
        ///   The height of an image
        /// </summary>
        [JsonProperty("height")]
        public uint Height { get; set; }

        /// <summary>
        ///   The url of an image
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        ///   The preview url of an image
        /// </summary>
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        ///   The list of full tags that are on the image
        /// </summary>
        [JsonProperty("tags")]
        public WaifuImageTag[] Tags { get; set; }

        /// <summary>
        ///   The artist who created the image
        /// </summary>
        [JsonProperty("artist")]
        public WaifuArtist Artist { get; set; }
    }
}
