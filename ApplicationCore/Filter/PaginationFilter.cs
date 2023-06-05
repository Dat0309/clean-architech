using ApplicationCore.Constants;

namespace ApplicationCore.Filer
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilter()
        {
            this.PageNumber = ContentManager.DefaultPageNumber;
            this.PageSize = ContentManager.DefaultPageSize;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"> Number of page need to display </param>
        /// <param name="pageSize"> Size of page need to display in onr page </param>
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize ;
        }
    }
}
