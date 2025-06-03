namespace Delegate_Nullable_Types.Entities
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Book(string name, string authorName, int pageCount)
        {
            Name = name ?? throw new ArgumentNullException("Name is required.");
            AuthorName = authorName ?? throw new ArgumentNullException("Author name is required.");
            PageCount = pageCount;
        }
        public string ShowInfo() => $"ID: {Id}, Name: {Name}, Author name: {AuthorName}, Page count: {PageCount}";
    }
}
