using Microsoft.EntityFrameworkCore;
using StudentApi.Data;
using StudentApi.Models;
using StudentApi.Data;

namespace StudentApi.Repository
{
    public class PicturesRepository : IPicturesRepository
    {
        StudentsDbContext context;

        public PicturesRepository(StudentsDbContext context)
        {
            this.context = context;
        }

        public async Task<Picture> AddPicture(Picture pic)
        {
            context.Picture.AddAsync(pic);
            context.SaveChanges();
            return pic;
        }

        public async Task<bool> DeletePicture(int id)
        {
            Picture deletePicture= await GetPictureById(id);
           context.Picture.Remove(deletePicture);
            context.SaveChanges();
            return true;
        }

        public async Task<List<Picture>> GetAllPictures()
        {
            return await context.Picture.ToListAsync();
        }

        public async Task<Picture> GetPictureById(int id)
        {
           return await context.Picture.FindAsync(id);
        }

        public async Task<bool> UpdatePicture(int id, Picture picture)
        {
            Picture updatePicture = await GetPictureById(id);
            if(updatePicture == null)
            {
                return false;
            }
            else
            {
				updatePicture.StudentId = picture.StudentId;
				updatePicture.ImageData = picture.ImageData;
                context.SaveChanges();
            }

            return true;
        }
    }
}
