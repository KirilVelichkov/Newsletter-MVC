using Bytes2you.Validation;
using NewsLetter.Data.Contracts;
using NewsLetter.Models.DbModels;
using NewsLetter.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Services
{
    public class TagsService : BaseDataService, ITagsService
    {

        private readonly IEfGenericRepository<Tag> tagsRepository;

        public TagsService(
            IEfGenericRepository<Tag> tagsRepository,
            Func<IUnitOfWork> unitOfWork)
            : base(unitOfWork)
        {
            Guard.WhenArgument(tagsRepository, nameof(tagsRepository)).IsNull().Throw();

            this.tagsRepository = tagsRepository;
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return this.tagsRepository.GetAll();
        }

        public Tag GetTagByName(string name)
        {
            return this.tagsRepository.GetFirst(x => x.TagName.ToLower() == name.ToLower());
        }

        public void CreateTag(string tagName)
        {
            Guard.WhenArgument(tagName, nameof(tagName)).IsNullOrEmpty().Throw();

            using (var uow = base.UnitOfWork())
            {
                this.tagsRepository.Add(new Tag()
                {
                    TagName = tagName.ToLower()
                });

                uow.Commit();
            }
        }
    }
}
