namespace WaifuIM.Web.Models
{
    /// <summary>
    ///   An object holding search filters for image searches
    /// </summary>
    public class SearchSettings
    {
        /// <summary>
        ///   The tags to be included with image searches
        /// </summary>
        /// <value><see cref="WaifuTag"/> array</value>
        public WaifuTag[] IncludedTags { get; set; }

        /// <summary>
        ///   The tags to be excluded with image searches
        /// </summary>
        /// <value><see cref="WaifuTag"/> array</value>
        public WaifuTag[] ExcludedTags { get; set; }

        /// <summary>
        ///   If image searches should have not safe for work content
        /// </summary>
        public bool IsNsfw { get; set; }

        /// <summary>
        ///   If image searches should return .GIF files only
        /// </summary>
        public bool OnlyGif { get; set; }

        /// <summary>
        ///   The order of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="WaifuImageOrder"/></value>
        public WaifuImageOrder OrderBy { get; set; }

        /// <summary>
        ///   The orientation of images meeting the search criteria should be in
        /// </summary>
        /// <value><see cref="Enums.Orientation"/></value>
        public WaifuImageOrientation Orientation { get; set; }

        /// <summary>
        ///   The preferred height for an image
        /// </summary>
        public string Height { get; set; }

        /// <summary>
        ///   The preferred width for an image
        /// </summary>
        public string Width { get; set; }

        /// <summary>
        ///   The size in bytes for an image
        /// </summary>
        public string ByteSize { get; set; }

        /// <summary>
        ///   If the image search should return at most 30 images meeting the search criteria
        /// </summary>
        public bool ManyFiles { get; set; }

        /// <summary>
        ///   If the image search should return every result meeting the search criteria (> 30 images).
        ///   NOTE: For admins only
        /// </summary>
        public bool FullResult { get; set; } = false;

        /// <summary>
        ///   The image url's or signatures to be included with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        public string[] IncludedFiles { get; set; }

        /// <summary>
        ///   The image url's or signatures to be excluded with image searches
        /// </summary>
        /// <value><see cref="string[]"/> array</value>
        public string[] ExcludedFiles { get; set; }
    }
}
