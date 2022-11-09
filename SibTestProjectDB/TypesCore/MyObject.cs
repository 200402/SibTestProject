namespace SibTestProjectDB.TypesCore
{
    public class MyObject
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; } //владелец файла
        public string Name { get; set; } // Название файла
        public Guid? ParentId { get; set; } //папка в которой объект находится
        public string Type { get; set; } //это папка "folder" или "object"
        public DateTime CreationDate { get; set; } 
        public int NestingLevel { get; set; }
        public ulong? Size { get; set; } //нужен ли?
    }
}
