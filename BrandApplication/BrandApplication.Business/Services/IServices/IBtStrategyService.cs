using System.Collections.Generic;
using System.Threading.Tasks;
using BrandApplication.Business.DTOs; // Correct DTO namespace

namespace BrandApplication.Business.Services.IServices // Corrected namespace
{
    public interface IBtStrategyService
    {
        Task<IEnumerable<BtStrategyDto>> GetAllStrategiesAsync();
        Task<BtStrategyDto> GetStrategyByIdAsync(int id); // Changed id type to int, return type to Dto
        Task<BtStrategyDto> CreateStrategyAsync(BtStrategyDto strategyDto); // Changed parameter and return type to Dto
        Task UpdateStrategyAsync(int id, BtStrategyDto strategyDto); // Added id parameter, changed parameter to Dto
        Task DeleteStrategyAsync(int id); // Changed id type to int
    }
}