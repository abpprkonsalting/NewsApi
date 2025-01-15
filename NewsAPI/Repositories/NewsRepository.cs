using NewsAPI.Data;
using NewsAPI.Model;

namespace NewsAPI.Repositories
{
    public interface INewsRepository : IRepository<News>{}

    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(NewsAPIContext context) : base(context){}
    }
}
