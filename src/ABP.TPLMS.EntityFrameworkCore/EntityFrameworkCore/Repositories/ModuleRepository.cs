using Abp.EntityFrameworkCore;
using ABP.TPLMS.Entities;
using ABP.TPLMS.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABP.TPLMS.EntityFrameworkCore.Repositories
{
    public class ModuleRepository : TPLMSRepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(IDbContextProvider<TPLMSDbContext> dbContextProvider) :
            base(dbContextProvider)
        {

        }
        public bool Delete(string ids)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Module> LoadModules(int pageIndex, int pageSize)
        {
            return Context.Modules.OrderBy(u => u.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
