namespace Mission11_Pesante.Models.ViewModels
{
    public class PaginationInfo
    {
        // Properties to store pagination information

        // Represents the total number of items across all pages
        public int TotalItems { get; set; }

        // Represents the number of items displayed per page
        public int ItemsPerPage { get; set; }

        // Represents the current page being viewed
        public int CurrentPage { get; set; }

        // Calculated property to determine the total number of pages
        // This is calculated based on TotalItems and ItemsPerPage
        // It uses Math.Ceiling to ensure that even if there are remaining items,
        // an additional page is created to accommodate them
        public int TotalNumPages => (int)(Math.Ceiling((decimal)TotalItems / ItemsPerPage));
    }
}
