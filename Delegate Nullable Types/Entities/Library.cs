using Utils.Exceptions;

namespace Delegate_Nullable_Types.Entities
{
    public class Library : Entity
    {
        public int BookLimit { get; set; }
        private readonly List<Book> Books = [];
        public void AddBook(Book book)
        {
            if (Books.Any(b => b.Name == book.Name && !b.IsDeleted))
                throw new AlreadyExistsException("A book with this name already exists and is not deleted.");

            if (Books.Count(b => !b.IsDeleted) >= BookLimit)
                throw new CapacityLimitException("You cannot add any books because the limit is full.");

            Books.Add(book);
        }
        public Book GetById(int? id)
        {
            if (id == null) throw new NullReferenceException("Id cannot be null.");
            return Books.Find(b => b.Id == id && !b.IsDeleted);
        }
        public List<Book> GetAllBooks()
        {
            var allBooks = new List<Book>();
            allBooks.AddRange(Books);
            return allBooks;
        }
        public void DeleteBookById(int? id)
        {
            if (id == null) throw new NullReferenceException("Id cannot be null");
            var book = Books.Find(m=>m.Id == id && !m.IsDeleted);
            if (book == null) throw new NotFoundException("Book not found or already deleted.");
            book.IsDeleted = true;
        }
        public void EditBookName(int? id,string newName)
        {
            if (id == null) throw new NullReferenceException("Id cannot be null");
            var book = Books.Find(m => m.Id == id && !m.IsDeleted);
            if (book == null) throw new NotFoundException("Book not found or already deleted.");
            book.Name = newName;
        }
        public List<Book> FilterByPageCount(int minPageCount, int maxPageCount) => 
            Books.FindAll(m=>m.PageCount>minPageCount && m.PageCount<maxPageCount&& !m.IsDeleted);

    }
}
