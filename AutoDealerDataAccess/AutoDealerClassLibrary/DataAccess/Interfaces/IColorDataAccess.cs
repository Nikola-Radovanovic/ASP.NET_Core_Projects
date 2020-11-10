using AutoDealerClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess.Interfaces
{
    public interface IColorDataAccess
    {
        Task<List<ColorModel>> GetColors();
    }
}