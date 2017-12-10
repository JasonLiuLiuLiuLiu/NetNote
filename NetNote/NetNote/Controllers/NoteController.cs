using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetNote.Models;
using NetNote.Repository;
using NetNote.ViewModel;

namespace NetNote.Controllers
{
    public class NoteController : Controller
    {
        private INoteRespository _noteRespository;
        private INoteTypeRepository _noteTypeRepository;

        public NoteController(INoteRespository noteRespository,INoteTypeRepository noteTypeRepository)
        {
            _noteTypeRepository = noteTypeRepository;
            _noteRespository = noteRespository;
        }

        public async Task<IActionResult> Index(int pageindex=1)
        {
            var pagesize = 5;
            var notes = _noteRespository.PageList(pageindex, pagesize);
            ViewBag.PageCount = notes.Item2;
            ViewBag.PageIndex = pageindex;
            return View(notes.Item1);
        }
        public async Task<IActionResult> Add()
        {
            var types = await _noteTypeRepository.ListAsync();
            ViewBag.Types = types.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NoteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _noteRespository.AddAsync(new Note()
            {
                Tile = model.Tile,
                Content = model.Content,
               TypeId = model.Type==0?1:model.Type,
                Create = DateTime.Now
            });
            return RedirectToAction("Index");
        }
    }
}