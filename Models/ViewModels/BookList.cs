using Mission11_Pesante.Models.ViewModels;

namespace Mission11_Pesante.Models.ViewModels
{
    public class BookList
    {
        public IQueryable<Book> Books { get; set; }
        public PaginationInfo PaginationInfo { get; set; }  = new PaginationInfo();
    }
}
