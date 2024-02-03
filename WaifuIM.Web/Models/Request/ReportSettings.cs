using Newtonsoft.Json;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding the response from reporting an image on Waifu.IM
    /// </summary>
    public class ReportSettings
    {
        /// <summary>
        ///   The ID of the image that is being reported
        /// </summary>
        [JsonProperty("image_id")]
        public uint ImageId { get; set; } = 0;

        /// <summary>
        ///   The reason for why a given image should be reported
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;
    }
}
