using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Contracts
{
    public interface ITagsService 
    {
        IEnumerable<Tag> GetAllTags();

        void CreateTag(string tag);

        Tag GetTagByName(string name);
    }
}
