using AutoDealerClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AutoDealerClassLibrary.DataAccess.Interfaces
{
    public interface ICarConditionDataAccess
    {
        Task<List<CarConditionModel>> GetCarConditions();
    }
}