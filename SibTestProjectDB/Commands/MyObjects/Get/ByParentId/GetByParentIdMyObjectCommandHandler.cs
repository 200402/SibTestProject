﻿using MediatR;
using SibTestProjectDB.CoreTypes;
using SibTestProjectDB.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SibTestProjectDB.Commands.MyObjects.Get.ByParentId
{
    internal class GetByParentIdMyObjectCommandHandler : IRequestHandler<GetByParentIdMyObjectCommand, MyObject>
    {
        private readonly IMyObjectContext _dbContext;
        public GetByParentIdMyObjectCommandHandler(IMyObjectContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<MyObject> Handle(GetByParentIdMyObjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.MyObjects.FindAsync(new object[] { request.ParentId }, cancellationToken);
            if (entity == null)
            {
                return new MyObject();
            }

            return entity;
        }
    }
}
