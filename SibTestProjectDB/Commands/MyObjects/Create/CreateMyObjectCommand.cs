using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace SibTestProjectDB.Commands.MyObjects.Create
{
    internal class CreateMyObjectCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; } // Название файла
        public string Parent { get; set; } //папка в которой объект находится
        public string Type { get; set; } //это папка "folder" или "object"
        public DateTime CreationDate { get; set; }
        public ulong Size { get; set; } //нужен ли?
    }
}
