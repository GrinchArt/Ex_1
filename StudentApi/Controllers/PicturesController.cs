using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Repository;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicturesController : ControllerBase
    {
        private readonly IPicturesRepository _context;

        public PicturesController(IPicturesRepository context)
        {
            _context = context;
        }

        // GET: api/Pictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Picture>>> GetPictures()
        {
            IEnumerable<Picture> getPictures = await _context.GetAllPictures();
            if (getPictures == null)
            {
                return NotFound();
            }
            return Ok(getPictures);
        }

        // GET: api/Pictures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Picture>> GetPicture(int id)
        {
            Picture getPicture = await _context.GetPictureById(id);
            if (getPicture == null)
            {
                return NotFound();
            }
            return Ok(getPicture);
        }

        // PUT: api/Pictures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPicture(int id, Picture picture)
        {
            if (id != picture.Id)
            {
                return BadRequest();
            }
            bool updatePicture = await _context.UpdatePicture(id, picture);
            if (!updatePicture) 
            { return NotFound(); }
            return NoContent();
        }

        // POST: api/Pictures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Picture>> PostPicture(Picture picture)
        {

            Picture newPicture = await _context.AddPicture(picture);
            return Ok(newPicture);
        }

        // DELETE: api/Pictures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePicture(int id)
        {
            bool deletePicture = await _context.DeletePicture(id);
            if (!deletePicture)
            {
                return NotFound();
            }
            return NoContent();
        }    
    }
}
