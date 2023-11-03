using Backend.Data;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/Notes")]
    public class NotesController :ControllerBase
    {
        [HttpGet]
        public List<NotesModel> Getnotess()
        {
            return NotesData.GetNotes();
        }
        [HttpGet("{id}")]
        public NotesModel Getnotes(int id)
        {
            return NotesData.GetNote(id);
        }
        [HttpPost]
        public bool PostStudent(NotesModel notes)
        {
            return NotesData.Create(notes);
        }
        [HttpPut("{id}")]
        public bool Putnotes(NotesModel notes, int id)
        {
            return NotesData.Update(notes, id);
        }
        [HttpDelete("{id}")]
        public bool Deletenotes(int id)
        {
            return NotesData.Delete(id);
        }
    }
}
