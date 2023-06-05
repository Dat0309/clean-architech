using ApplicationCore.Constants;
using ApplicationCore.Filer;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using System.Net;

namespace ApplicationCore.Helpers
{
    public class PaginationHelper
    {
        /// <summary>
        /// Create paged response attach: page data, support pagination, message, status code, next-pre-last-first URL
        /// </summary>
        /// <typeparam name="T"> T is class of type return </typeparam>
        /// <param name="pagedData"> data </param>
        /// <param name="validFilter"> check valid filter from pagination filter </param>
        /// <param name="totalRecords"> total record to display </param>
        /// <param name="uriService"> Uri Service help us created next, previous, last and first URL, usefull to FE </param>
        /// <param name="route"> Current Route of API </param>
        /// <param name="msg"> Message of Response </param>
        /// <param name="succeeded"> status off Response </param>
        /// <param name="statusCode"> Status code of Response </param>
        /// <returns></returns>
        public static PagedResponse<IEnumerable<T>> CreatePagedReponse<T>(IEnumerable<T> pagedData, PaginationFilter validFilter, int totalRecords, IUriReposiroty uriService, string route, string msg, bool succeeded, HttpStatusCode statusCode)
        {
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            // get total record and rounded it.
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            var respose = new PagedResponse<IEnumerable<T>>(pagedData, validFilter.PageNumber, validFilter.PageSize, totalRecords, roundedTotalPages, statusCode, msg, succeeded);

            // Generate router of next - pre - last - first page
            respose.NextPage =
                validFilter.PageNumber >= 1 && validFilter.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber + 1, validFilter.PageSize), route)
                : null;
            respose.PreviousPage =
                validFilter.PageNumber - 1 >= 1 && validFilter.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationFilter(validFilter.PageNumber - 1, validFilter.PageSize), route)
                : null;

            respose.FirstPage = uriService.GetPageUri(new PaginationFilter(1, validFilter.PageSize), route);
            respose.LastPage = roundedTotalPages > 1 ? uriService.GetPageUri(new PaginationFilter(roundedTotalPages, validFilter.PageSize), route) : null;
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
