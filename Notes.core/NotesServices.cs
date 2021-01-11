using Notes.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Notes.core
{
    public class NotesServices: INotesServices
    {
        private readonly AppDbContext _context;

        public NotesServices(AppDbContext context)
        {
            _context = context;
        }
        public List<Note> GetNotes()
        {
            return _context.Notes.ToList(); ;
        }


        public Note CreateNote(Note note)
        {
            _context.Add(note);
            _context.SaveChanges();

            return note;
        }
        public Note GetNote(int id)
        {
            return _context.Notes.First(n => n.Id == id);
        }
        public void DeleteNote(int id)
        {
            var note = _context.Notes.First(n => n.Id == id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public void EditNote(Note note)
        {
            var editedNote = _context.Notes.First(n => n.Id == note.Id);
            editedNote.value = note.value;
            _context.SaveChanges();
        }

    }
}
