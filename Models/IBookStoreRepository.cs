namespace Mission11_Pesante.Models
{
    // Interface representing a book store repository
    public interface IBookStoreRepository
    {
        // Property representing a queryable collection of books
        public IQueryable<Book> Book { get; }
    }
}
