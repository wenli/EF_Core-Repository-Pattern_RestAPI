using AutoMapper;
using BrandApplication.Business.CustomExceptions;
using BrandApplication.Business.DTOs;
using BrandApplication.Business.Services.IServices;
using BrandApplication.DataAccess.Entities;
using BrandApplication.DataAccess.Interfaces; // For IUnitOfWork and IRepository
using Microsoft.EntityFrameworkCore; // For ToListAsync
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandApplication.Business.Services.Services
{
    public class BtStrategyEntityService : IBtStrategyService
    {
        private readonly IRepository<BtStrategy> _repository;
        private readonly IMapper _mapper;

        public BtStrategyEntityService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = unitOfWork.Repository<BtStrategy>();
            _mapper = mapper;
        }

        public async Task<IEnumerable<BtStrategyDto>> GetAllStrategiesAsync()
        {
            var strategies = await _repository.ReadsAsync().ToListAsync();
            return _mapper.Map<IEnumerable<BtStrategyDto>>(strategies);
        }

        public async Task<BtStrategyDto> GetStrategyByIdAsync(int id)
        {
            var strategy = await _repository.ReadAsync(s => s.Id == id);
            if (strategy == null)
            {
                throw new EntityNotFoundException($"BtStrategy with id {id} not found.");
            }
            return _mapper.Map<BtStrategyDto>(strategy);
        }

        public async Task<BtStrategyDto> CreateStrategyAsync(BtStrategyDto strategyDto)
        {
            var strategy = _mapper.Map<BtStrategy>(strategyDto);
            // Assuming Id is database generated, it should not be set here if it's a new entity.
            // If DTO carries an Id for creation, ensure it's handled (e.g. ignored or checked)
            // For now, we assume the mapping doesn't try to set a client-generated Id that conflicts.
            await _repository.CreateAsync(strategy);
            await _repository.SaveChangesAsync(); // Or _unitOfWork.Save() if it's async and preferred
            return _mapper.Map<BtStrategyDto>(strategy); // Map back to DTO, Id should be populated
        }

        public async Task UpdateStrategyAsync(int id, BtStrategyDto strategyDto)
        {
            var existingStrategy = await _repository.ReadAsync(s => s.Id == id);
            if (existingStrategy == null)
            {
                throw new EntityNotFoundException($"BtStrategy with id {id} not found for update.");
            }

            _mapper.Map(strategyDto, existingStrategy); // Update existing entity with DTO values
            // Ensure Id from path is used, not from DTO, or they match.
            // existingStrategy.Id is already 'id'
            
            await _repository.UpdateAsync(existingStrategy);
            await _repository.SaveChangesAsync(); // Or _unitOfWork.Save()
        }

        public async Task DeleteStrategyAsync(int id)
        {
            var strategy = await _repository.ReadAsync(s => s.Id == id);
            if (strategy == null)
            {
                throw new EntityNotFoundException($"BtStrategy with id {id} not found for deletion.");
            }
            await _repository.DeleteAsync(strategy);
            await _repository.SaveChangesAsync(); // Or _unitOfWork.Save()
        }
    }
}
