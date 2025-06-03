using Utils.Enums;

namespace Delegate_Nullable_Types.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public User(string username, string email, Role role)
        {
            Username = username ?? throw new ArgumentNullException("Username is required.");
            Email = email ?? throw new ArgumentNullException("Email is required.");
            Role = role;
        }
        public string ShowInfo()=>$"ID: {Id}, Username: {Username}, Email: {Email}, Role: {Role}";
        
    }
}
