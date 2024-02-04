using WaifuIM.Web.Extensions;
using WaifuIM.Web.Models;

namespace WaifuIM.Web.Utilities
{
    internal static class QueryUtility
    {
        internal static string FormatQueryParams(SearchSettings settings)
        {
            string query = "?";
            if (settings != null)
            {
                query += AddQueryParam("included_tags", settings.IncludedTags);
                query += AddQueryParam("excluded_tags", settings.ExcludedTags);
                query += AddQueryParam("is_nsfw", settings.IsNsfw);
                query += AddQueryParam("gif", settings.OnlyGif);
                query += AddQueryParam("order_by", settings.OrderBy.GetEnumMemberValue());
                string s = settings.Orientation.GetEnumMemberValue();
                query += AddQueryParam("orientation", s);
                query += AddQueryParam("height", settings.Height);
                query += AddQueryParam("width", settings.Width);
                query += AddQueryParam("byte_size", settings.ByteSize);
                query += AddQueryParam("many", settings.ManyFiles);
                query += AddQueryParam("full", settings.FullResult);
                query += AddQueryParam("included_files", settings.IncludedFiles);
                query += AddQueryParam("excluded_files", settings.ExcludedFiles);

                return query.Substring(0, query.Length - 1);
            }

            return query.Substring(0, query.Length - 1);
        }

        private static string AddQueryParam(string key, WaifuTag[] value)
        {
            if (value != null)
            {
                string result = string.Empty;
                foreach (object item in value)
                {
                    result += AddQueryParam(key, item.ToString().ToLowerInvariant());
                }

                return result;
            }

            return string.Empty;
        }

        private static string AddQueryParam(string key, string[] value)
        {
            if (value != null)
            {
                string result = string.Empty;
                foreach (object item in value)
                {
                    result += AddQueryParam(key, item.ToString().ToLowerInvariant());
                }

                return result;
            }

            return string.Empty;
        }

        private static string AddQueryParam(string key, object value)
        {
            if (value != null)
            {
                return $"{key}={value}&";
            }

            return string.Empty;
        }
    }
}
