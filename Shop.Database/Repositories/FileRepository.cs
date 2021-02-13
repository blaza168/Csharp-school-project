using System.Threading.Tasks;
using Shop.Domain.Models;

namespace Shop.Database.Repositories
{
    public class FileRepository
    {
        private readonly ApplicationDbContext _context;

        public FileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<int> CreateFile(File file)
        {
            _context.Files.Add(file);

            return _context.SaveChangesAsync();
        }
        
        public string GetFilenameOnDisk(File file)
        {
            return file.Id.ToString("X");
        }
    }
}