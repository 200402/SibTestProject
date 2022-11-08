using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.TypesIntermediate
{
    public class UserInfo
    {
        public string Login { get; set; }
        public long SizeOfTheAvailableStorage { get; set; } = (8L * 1024L * 1024L * 1024L);
        public long FreeSpace { get; set; }
    }
}
