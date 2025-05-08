using System.Collections.Generic;
using System.Threading.Tasks;
using BrandApplication.DataAccess.Entities;

namespace BrandApplication.DataAccess.Services
{
    public interface IBtStrategyService
    {
        Task<IEnumerable<BtStrategy>> GetAllStrategiesAsync();
        Task<BtStrategy> GetStrategyByIdAsync(string id); // Assuming you have an ID property
        Task<BtStrategy> CreateStrategyAsync(BtStrategy strategy);
        Task UpdateStrategyAsync(BtStrategy strategy);
        Task DeleteStrategyAsync(string id);

        // Add any other methods specific to your business logic, e.g.:
        // Task<IEnumerable<BtStrategy>> GetStrategiesBySymbolAsync(string symbol);
        // Task RunBacktestAsync(string strategyId);
    }
}