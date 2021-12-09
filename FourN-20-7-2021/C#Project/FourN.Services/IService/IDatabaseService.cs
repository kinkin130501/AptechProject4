using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourN.Services.IService
{
    public interface IDatabaseService
    {
        Task<bool> CreateBackup(string path);
    }
}
