using NewsAPI.Data;
using NewsAPI.Model;

namespace NewsAPI.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
        News Add(News news,IFormFile file);
        News Update(News news, IFormFile? file);
    }

    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(NewsAPIContext context) : base(context){}

        public News Update(News news, IFormFile? file)
        {
            try
            {
                if (file != null)
                {
                    news.ImageUrl = SaveImage(file);
                }
                return Update(news);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public News Add(News news, IFormFile? file)
        {
            try
            {
                if (file != null)
                {
                    news.ImageUrl = SaveImage(file);
                }
                return Add(news);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string SaveImage(IFormFile file)
        {
            try
            {
                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");
                string fullPath = Path.Combine(pathToSave, file.FileName);
                using FileStream stream = new(fullPath, FileMode.Create);
                file.CopyTo(stream);
                return "images/" + file.FileName;
            }
            catch (Exception ex)
            {
                return "images/default_image.png";
            }
        }
    }
}
