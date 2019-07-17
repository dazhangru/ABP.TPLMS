using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using ABP.TPLMS.Entities;
using ABP.TPLMS.Modules.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Modules
{
    public class ModuleAppService : ApplicationService, IModuleAppService
    {
        private readonly IRepository<Module> repository;
        public ModuleAppService(IRepository<Module> repository)
        {
            this.repository = repository;
        }
        public Task CreateAsync(CreateUpdateModuleDto input)
        {
            var module = Mapper.Map<Module>(input);
            return repository.InsertAsync(module);
        }

        public void Delete(int Id)
        {
            repository.Delete(Id);
        }

        public async Task DeleteAsync(int Id)
        {
            await repository.DeleteAsync(Id);
        }

        public async Task<ListResultDto<ModuleDto>> GetAllAsync()
        {
            var books=await repository.GetAllListAsync();
            return new ListResultDto<ModuleDto>(ObjectMapper.Map<List<ModuleDto>>(books));
        }

        public Task UpdateAsync(CreateUpdateModuleDto input)
        {
            var module = Mapper.Map<Module>(input);
            return repository.UpdateAsync(module);
        }
    }
}
