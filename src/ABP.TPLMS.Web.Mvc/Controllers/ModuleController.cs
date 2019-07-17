using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABP.TPLMS.Controllers;
using ABP.TPLMS.Entities;
using ABP.TPLMS.Modules;
using ABP.TPLMS.Modules.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ABP.TPLMS.Web.Mvc.Controllers
{
    public class ModuleController : TPLMSControllerBase
    {
        private readonly IModuleAppService _moduleAppService;
        public ModuleController(IModuleAppService moduleAppService)
        {
            _moduleAppService = moduleAppService;
        }
        public IActionResult Index()
        {
            var output = _moduleAppService.GetAllAsync();
            var model = new EditModuleModalViewModel
            {
                Module = output.Result.Items.FirstOrDefault(),
                Modules = output.Result.Items
            };
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateUpdateModuleDto dto)
        {
            _moduleAppService.CreateAsync(dto);
            var output = _moduleAppService.GetAllAsync();
            return PartialView("_List", output);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, EditModuleModalViewModel updateDto)
        {
            if (Id != updateDto.Module.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //????
                    var module = Mapper.Map<CreateUpdateModuleDto>(updateDto.Module);
                    _moduleAppService.UpdateAsync(module);
                }
                catch (DbUpdateConcurrencyException ex)
                {

                    if (!DtoExists(updateDto.Module.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw ex;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(updateDto);
        }
        public bool DtoExists(long id)
        {
            return _moduleAppService.GetAllAsync().Result.Items.Any(e => e.Id == id);
        }
        public IActionResult Edit(long? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var module = _moduleAppService.GetAllAsync().Result.Items.SingleOrDefault(e => e.Id == Id);
            if (module == null)
            {
                return NotFound();
            }
            EditModuleModalViewModel model = new EditModuleModalViewModel
            {
                Module = module
            };
            return View(model);
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var module = _moduleAppService.GetAllAsync().Result.Items.SingleOrDefault(e => e.Id == Id);
            if (module == null)
            {
                return NotFound();
            }
            var model = new EditModuleModalViewModel
            {
                Module = module
            };

            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            try
            {
                await _moduleAppService.DeleteAsync(Id);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
    }
}