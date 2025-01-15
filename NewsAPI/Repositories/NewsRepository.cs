using NewsAPI.Data;
using NewsAPI.Model;

namespace NewsAPI.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
        News Add(News news,IFormFile file);
    }

    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(NewsAPIContext context) : base(context){}

        public News Add(News news, IFormFile? file)
        {
            try
            {
                if (file != null)
                {
                    string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");
                    string fullPath = Path.Combine(pathToSave, file.FileName);
                    using FileStream stream = new(fullPath, FileMode.Create);
                    file.CopyTo(stream);
                    news.ImageUrl = "images/" + file.FileName;
                }
                return Add(news);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            
        }
    }
}
