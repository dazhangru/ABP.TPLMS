using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ABP.TPLMS.Modules.Dto
{
   public interface IModuleAppService:IApplicationService
    {
        //展现层和应用服务层通过Dto进行数据传输
        Task CreateAsync(CreateUpdateModuleDto input);
        Task UpdateAsync(CreateUpdateModuleDto input);
        Task<ListResultDto<ModuleDto>> GetAllAsync();
        Task DeleteAsync(int Id);
        void Delete(int Id);
    }
}
