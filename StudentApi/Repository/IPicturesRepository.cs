using StudentApi.Models;

namespace StudentApi.Repository
{
    public interface IPicturesRepository
    {
        Task<List<Picture>> GetAllPictures();
        Task<Picture> GetPictureById(int id);
        Task<bool> DeletePicture(int id);
        Task<Picture> AddPicture(Picture pic);
        Task<bool> UpdatePicture(int id, Picture picture);
    }
}
