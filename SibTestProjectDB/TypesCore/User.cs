namespace SibTestProjectDB.TypesCore
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public long SizeOfTheAvailableStorage { get; set; } = (8L * 1024L * 1024L * 1024L);
        public long FreeSpace { get; set; }
    }
}
