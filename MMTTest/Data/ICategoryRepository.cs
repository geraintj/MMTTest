using System.Collections.Generic;
using System.Threading.Tasks;
using MMTTest.API.Models;

namespace MMTTest.API.Data
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
    }
}
