using Cleverbit.CodingTask.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cleverbit.CodingTask.Utilities.Interfaces
{
    public interface IMatchService
    {
        Task<List<UserMatch>> GetUserMatchAsync();
        Task<int> GetRandomNumberAsync();
    }
}
