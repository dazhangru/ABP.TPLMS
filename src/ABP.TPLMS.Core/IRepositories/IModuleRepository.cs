using Abp.Domain.Repositories;
using ABP.TPLMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.IRepositories
{
    public interface IModuleRepository:IRepository<Module>
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IEnumerable<Module> LoadModules(int pageIndex, int pageSize);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool Delete(string ids);
    }
}
