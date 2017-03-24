using NewsLetter.Models.DbModels;
using NewsLetter.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsLetter.Services.Data.Contracts
{
    public interface IArticleService
    {
        SingleArticleViewModel GetArticleById(int id);

        IEnumerable<ListArticleByCategoryViewModel> GetAllArticles();

        IEnumerable<CommentViewModel> GetArticleComments(int id);

        void AddCommentToArticle(Comment comment);

        void AddCommentReply(CommentReply comment);

        //IEnumerable<ListArticleByCategoryViewModel> GetAllArticles(int pageNumber, int pageSize);
    }
}
