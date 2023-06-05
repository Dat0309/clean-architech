using System.Net;

namespace ApplicationCore.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public Uri? FirstPage { get; set; }
        public Uri? LastPage { get; set; }
        public decimal? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
        public Uri? NextPage { get; set; }
        public Uri? PreviousPage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"> Data return of service </param>
        /// <param name="pageNumber"> Number of page need to display </param>
        /// <param name="pageSize"> Size of page need to display </param>
        /// <param name="totalRecords"> Total record per page </param>
        /// <param name="totalPages"> total pages of all data </param>
        /// <param name="statusCode"> status code of response </param>
        /// <param name="msg"> message of response </param>
        /// <param name="succeeded"> sttus of response </param>
        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords, int totalPages, HttpStatusCode statusCode, string msg, bool succeeded)
        {
            this.statusCode = statusCode;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.TotalPages = totalPages;
            this.Message = msg;
            this.Succeeded = succeeded;
            this.currentDate = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Data return of service</param>
        /// <param name="totalRecords">total pages of all data</param>
        /// <param name="msg">message of response</param>
        /// <param name="succeeded">sttus of response</param>
        /// <param name="statusCode">status code of response</param>
        public PagedResponse(T data, int totalRecords, string msg, bool succeeded, HttpStatusCode statusCode)
        {
            this.statusCode
                 = statusCode;
            this.Data = data;
            this.TotalRecords = totalRecords;
            this.Message = msg;
            this.Succeeded = succeeded;
            this.currentDate = DateTime.Now;
        }
    }
}
