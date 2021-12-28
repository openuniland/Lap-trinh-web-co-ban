
namespace BtlWebForm.Entity
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int Role { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public UserEntity() { }
        public UserEntity(int ID, string Username, string Password, string Fullname, int Role, string Address, string PhoneNumber)
        {
            this.ID = ID;
            this.Username = Username;
            this.Password = Password;
            this.Fullname = Fullname;
            this.Role = Role;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
        public void changeUserEntity(string Fullname, int Role, string Address, string PhoneNumber)
        {
            this.Fullname = Fullname;
            this.Role = Role;
            this.Address = Address;
            this.PhoneNumber = PhoneNumber;
        }
    }
}