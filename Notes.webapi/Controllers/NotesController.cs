using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Notes.core;
using Notes.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly ILogger<NotesController> _logger;
        private  INotesServices _notesservices;

        public NotesController(ILogger<NotesController> logger,INotesServices notesservices)
        {
            _logger = logger;

            _notesservices = notesservices;
        }
        [HttpGet]
        public IActionResult GetNotes()
        {
            return Ok(_notesservices.GetNotes());
        }

        [HttpGet("{id}",Name ="GetNote")]
        public IActionResult GetNote(int id)
        {
            return Ok(_notesservices.GetNote(id));
        }
        [HttpPost]
        public IActionResult GetNotes(Note note)
        {
            var newNote = _notesservices.CreateNote(note);
            return CreatedAtRoute("GetNote", new { newNote.Id }, newNote);

         
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNote(int id)
        {
            _notesservices.DeleteNote(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditNote([FromBody] Note note)
        {
            _notesservices.EditNote(note);
            return Ok();
        }


    }

}
