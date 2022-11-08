using System.IO;

namespace FileManager
{
    public class Repository
    {
        public static int newUser(string userName)
        {
            try
            {
                Directory.CreateDirectory($"../AllUsersFiles/{userName}");
                return 200;
            } 
            catch (Exception ex) 
            { 
                Console.WriteLine(ex); 
                return -1;
            }
        }

    }
}