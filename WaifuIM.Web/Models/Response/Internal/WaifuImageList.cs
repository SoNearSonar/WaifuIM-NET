using Newtonsoft.Json;
using System.Collections.Generic;

namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding a list of images
    /// </summary>
    internal class WaifuImageList
    {
        /// <summary>
        /// The list of images returned from the search
        /// </summary>
        [JsonProperty("images")]
        public List<WaifuImage> Images { get; set; }
    }
}
