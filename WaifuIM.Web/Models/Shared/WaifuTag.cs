using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace WaifuIM.Web.Models
{
    /// <summary>
    /// The tag name that images can have
    /// </summary>
    
    // Used in both requests and responses
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WaifuTag
    {
        // Versatile
        [EnumMember(Value = "maid")] Maid,
        [EnumMember(Value = "waifu")] Waifu,
        [EnumMember(Value = "marin-kitagawa")] MarinKitagawa,
        [EnumMember(Value = "mori-calliope")] MoriCalliope,
        [EnumMember(Value = "raiden-shogun")] RaidenShogun,
        [EnumMember(Value = "oppai")] Oppai,
        [EnumMember(Value = "selfies")] Selfies,
        [EnumMember(Value = "uniform")] Uniform,

        // NSFW
        [EnumMember(Value = "ass")] Ass,
        [EnumMember(Value = "hentai")] Hentai,
        [EnumMember(Value = "milf")] Milf,
        [EnumMember(Value = "oral")] Oral,
        [EnumMember(Value = "paizuri")] Paizuri,
        [EnumMember(Value = "ecchi")] Ecchi,
        [EnumMember(Value = "ero")] Ero
    }
}
