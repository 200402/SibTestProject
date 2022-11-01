namespace SibTestProjectDB.Data.CoreTypes
{
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; } //папка в которой объект находится
        public string Master { get; set; } //владелец файла
        public string Type { get; set; } //папка "folder" или "object"
        public ulong Size { get; set; } //нужен ли?
    }
}
