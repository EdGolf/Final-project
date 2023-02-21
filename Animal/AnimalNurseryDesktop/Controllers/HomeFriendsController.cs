using AnimalNursery.Models.Animals;
using AnimalNursery.Models;
using AnimalNursery.Services;
using Microsoft.AspNetCore.Mvc;
using AnimalNursery.Models.Request;
using System.Reflection.PortableExecutable;

namespace AnimalNursery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeFriendsController : ControllerBase
    {
        private IHomeFriendsRepository _homeFriendsRepository;

        public HomeFriendsController(IHomeFriendsRepository homeFriendsRepository)
        {
            _homeFriendsRepository = homeFriendsRepository;
        }

        [HttpPost("create")]
        public ActionResult<int> Create ([FromBody] CreateHomeFriendsRequest createHomeFriendsRequest)
        {
            HomeFriend homeFriend  = CreateAnimal.create(createHomeFriendsRequest.Type);
            homeFriend.Name = createHomeFriendsRequest.Name;
            homeFriend.Commands = createHomeFriendsRequest.Commands.Split(", ").ToList();
            homeFriend.Birthday = createHomeFriendsRequest.Birthday;
            return Ok(_homeFriendsRepository.Create(homeFriend));
        }

        [HttpPut("update")]
        public ActionResult<int> Update([FromBody] UpdateHomeFriendsRequest updateHomeFriendsRequest)
        {
            HomeFriend homeFriend = CreateAnimal.create(updateHomeFriendsRequest.Type);
            homeFriend.Id = updateHomeFriendsRequest.Id;
            homeFriend.Name = updateHomeFriendsRequest.Name;
            homeFriend.Commands = updateHomeFriendsRequest.Commands.Split(", ").ToList();
            homeFriend.Birthday = updateHomeFriendsRequest.Birthday;
            return Ok(_homeFriendsRepository.Update(homeFriend));
        }


        [HttpDelete("delete")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_homeFriendsRepository.Delete(id));
        }

        [HttpGet("get-all")]
        public ActionResult<List<HomeFriend>> GetAll()
        {
            return Ok(_homeFriendsRepository.GetAll());
        }

        [HttpGet("get-by-id")]
        public ActionResult<HomeFriend> GetById(int id)
        {
            return Ok(_homeFriendsRepository.GetById(id));
        }



    }
}