using ABP.TPLMS.Entities;
using ABP.TPLMS.Modules.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABP.TPLMS.Modules
{
    public class EditModuleModalViewModel
    {
        public ModuleDto Module { get; set; }

        public IReadOnlyList<ModuleDto> Modules { get; set; }
    }
}
