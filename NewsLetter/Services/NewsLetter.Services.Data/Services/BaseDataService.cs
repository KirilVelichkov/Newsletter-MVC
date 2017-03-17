using Bytes2you.Validation;
using NewsLetter.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Services
{
    public abstract class BaseDataService
    {
        private readonly Func<IUnitOfWork> unitOfWork;

        protected BaseDataService(Func<IUnitOfWork> unitOfWork)
        {
            Guard.WhenArgument(unitOfWork, nameof(Func<IUnitOfWork>)).IsNull().Throw();

            this.unitOfWork = unitOfWork;
        }

        protected Func<IUnitOfWork> UnitOfWork
        {
            get { return this.unitOfWork; }
        }
    }
}
