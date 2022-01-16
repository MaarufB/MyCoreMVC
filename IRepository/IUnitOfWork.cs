using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCoreMVC.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationTypeRepository ApplicationTypeRepository { get; }
    }
}
