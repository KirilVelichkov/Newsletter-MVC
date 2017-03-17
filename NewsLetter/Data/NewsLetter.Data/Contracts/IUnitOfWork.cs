using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
