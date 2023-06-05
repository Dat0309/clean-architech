using ApplicationCore.Filer;

namespace ApplicationCore.Interfaces
{
    public interface IUriReposiroty
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
