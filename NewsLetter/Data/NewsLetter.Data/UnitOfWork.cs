using NewsLetter.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Data
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(DbContext context)
        {
            this.context = context;
        }

        public bool Commit()
        {
            return this.context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            // Let ninject do it 
        }
    }
}
