using Delegate_Nullable_Types.Entities;
using Utils.Enums;

namespace Delegate_Nullable_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Role role;
            while (true)
            {
                Console.WriteLine("Enter role (Admin or Member): ");
                string roleInput = Console.ReadLine();

                if(Enum.TryParse(roleInput, true, out role)&& Enum.IsDefined(role)) break;

                Console.WriteLine("Invalid role. Please enter either 'Admin' or 'Member'.");
            }

            User user = new(username,email,role);

            Library library = new();
            library.BookLimit = 10;

            while (true) {
                Console.WriteLine("1. Add book.\n2. Get book.\n3. Get all books.\n4. Delete book by id\n5. Edit book name\n6. Filter by page count\n0. Quit");
               
                Console.Write("Select operation: ");
                string operation = Console.ReadLine();
                try
                {
                    switch (operation)
                    {
                        case "1":

                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Error: Only admins can add books.");
                                break;
                            }
                            Console.Write("Enter book name: ");
                            string bookName = Console.ReadLine();

                            Console.Write("Enter book author name: ");
                            string bookAuthor = Console.ReadLine();

                            Console.Write("Enter page count: ");
                            int pageCount = Convert.ToInt32(Console.ReadLine());

                            Book newBook = new Book(bookName, bookAuthor, pageCount);

                            library.AddBook(newBook);
                            Console.WriteLine("Book added successfully.");


                            break;

                        case "2":
                            Console.Write("Enter book id: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());

                            var book = library.GetById(searchId);
                            if (book == null)
                                Console.WriteLine("Book not found.");
                            else
                                Console.WriteLine(book.ShowInfo());
                            break;

                        case "3":
                            var books = library.GetAllBooks();
                            foreach (var b in books)
                                Console.WriteLine(b.ShowInfo());
                            break;

                        case "4":
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Error: Only admins can add books.");
                                break;
                            }
                            Console.Write("Enter book id to delete: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());

                            library.DeleteBookById(deleteId);
                            Console.WriteLine("Book deleted successfully.");
                            break;

                        case "5":
                            if (user.Role != Role.Admin)
                            {
                                Console.WriteLine("Error: Only admins can add books.");
                                break;
                            }
                            Console.Write("Enter book id to edit: ");
                            int editId = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter new book name: ");
                            string newName = Console.ReadLine();

                            library.EditBookName(editId, newName);
                            Console.WriteLine("Book name updated.");
                            break;

                        case "6":
                            Console.Write("Enter min page count: ");
                            int min = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Enter max page count: ");
                            int max = Convert.ToInt32(Console.ReadLine());

                            var filtered = library.FilterByPageCount(min, max);
                            if (filtered.Count == 0)
                                Console.WriteLine("No books found in this range.");
                            else
                            {
                                Console.WriteLine("Filtered Books:");
                                foreach (var b in filtered)
                                    Console.WriteLine(b.ShowInfo());
                            }
                            break;

                        case "0":
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
