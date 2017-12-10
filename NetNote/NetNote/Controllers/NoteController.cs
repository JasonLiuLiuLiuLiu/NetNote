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

        public NoteController(INoteRespository noteRespository)
        {
            _noteRespository = noteRespository;
        }

        public async Task<IActionResult> Index()
        {
            var notes = await _noteRespository.ListAsync();
            return View(notes);
        }
        public async Task<IActionResult> Add()
        {
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
                Create = DateTime.Now
            });
            return RedirectToAction("Index");
        }
    }
}