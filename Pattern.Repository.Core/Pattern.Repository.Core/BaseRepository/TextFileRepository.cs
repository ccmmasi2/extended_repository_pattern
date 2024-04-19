using Newtonsoft.Json;

namespace Pattern.Repository.Core.BaseRepository
{
    public class TextFileRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly string _filePath = "PathToFile.json";

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var reader = new StreamReader(_filePath);
            string json = await reader.ReadToEndAsync();
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAsync(T entity)
        {
            var data = await GetAllAsync();
            var list = data.ToList();
            list.Add(entity);
            await File.WriteAllTextAsync(_filePath, JsonConvert.SerializeObject(list));
        }

        public async Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
