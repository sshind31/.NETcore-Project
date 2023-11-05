using CRUDTrial.DAO;
using CRUDTrial.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTrial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDataController : ControllerBase
    {
        private UserDBContext db;
        public UserDataController(UserDBContext db)
        {
            this.db = db;
        }

        [HttpGet("GetById")]
        public UserData GetUserData(int id)
        {
            return db.UserDatas.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("Get/{id}")]
        public UserData GetUserDatabyId([FromRoute(Name= "id")] int id)
        {
            return db.UserDatas.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("GetAll")]
        public List<UserData> GetAllUserDatas()
        {
            return new List<UserData>(db.UserDatas);
        }

        [HttpPost("AddUserData")]
        public List<UserData> AddUserData([FromBody] UserData user)
        {
            db.UserDatas.Add(new UserData { UserName=user.UserName, UserMobNo=user.UserMobNo});
            db.SaveChanges();
            return new List<UserData>(db.UserDatas);
        }

        [HttpDelete("Delete/{id}")]
        public List<UserData> DeleteUserDatabyId([FromRoute(Name = "id")] int id)
        {
            db.UserDatas.Remove(db.UserDatas.FirstOrDefault(x => x.Id == id));
            db.SaveChanges();
            return new List<UserData>(db.UserDatas);
        }

    }
}
