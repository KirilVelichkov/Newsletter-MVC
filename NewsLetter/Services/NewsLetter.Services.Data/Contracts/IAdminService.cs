using NewsLetter.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Contracts
{
    public interface IAdminService
    {
        void CreateArticle(Article article);
    }
}
