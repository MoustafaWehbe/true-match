namespace api.Helpers
{
    public static class ResponseHelper
    {
        public static PagedResponse<T> CreatePagedResponse<T>(
            int totalItems,
            int totalPages,
            int currentPage,
            int pageSize,
            List<T> data
        )
        {
            return new PagedResponse<T>(totalItems, totalPages, currentPage, pageSize, data);
        }

        public static ApiResponse<T> CreateSuccessResponse<T>(T data)
        {
            return new ApiResponse<T>(200, "Success", data);
        }

        public static ApiResponse<T> CreateErrorResponse<T>(string message)
        {
            return new ApiResponse<T>(500, message, default!);
        }
    }
}
