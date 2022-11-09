using System.IO;

namespace FileManager
{
    public class Repository
    {
        public static int newUser(string userName)
        {
            Directory.CreateDirectory($"../AllUsersFiles/{userName}");
            return 200;
        }

    }
}