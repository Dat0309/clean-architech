using ApplicationCore.Constants;
using ApplicationCore.Filer;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.WebUtilities;

namespace Infrastructure.Data.Repositories
{
    public class UriRepository : IUriReposiroty
    {
        private readonly string _baseUri;

        public UriRepository(string baseUri)
        {
            _baseUri = baseUri;
        }

        /// <summary>
        /// This func support to get current page uri
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="route"></param>
        /// <returns></returns>
        public Uri GetPageUri(PaginationFilter filter, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), ContentManager.PageNumber, filter.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, ContentManager.PageSize, filter.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
