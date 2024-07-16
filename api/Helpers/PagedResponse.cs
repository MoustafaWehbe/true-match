namespace api.Helpers
{
    public class PagedResponse<T>
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<T> Data { get; set; }

        public PagedResponse(int totalItems, int totalPages, int currentPage, int pageSize, List<T> data)
        {
            TotalItems = totalItems;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;
            Data = data;
        }
    }
}