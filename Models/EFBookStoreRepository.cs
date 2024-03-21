
namespace Mission11_Pesante.Models
{
    public class EFBookStoreRepository : IBookStoreRepository
    {
        private BookstoreContext _context;
        public EFBookStoreRepository(BookstoreContext temp) 
        {
            _context = temp; 
        }
        public IQueryable<Book> Book =>_context.Books ;
    }
}
