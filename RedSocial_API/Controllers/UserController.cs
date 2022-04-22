using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;

using RedSocial_API.Models;
using RedSocial_API.Services;

namespace RedSocial_API.Controllers {
    [Route("api/[controller]"), ApiController]
    public class UserController : Controller {
        public UserService userService;

        public UserController(UserService userService) {
            this.userService = userService;
        }
        [HttpGet]
        public ActionResult<List<User>> Get() {
            return userService.Get();
        }
        [HttpPost]
        public ActionResult<User> Create(User user) {
            userService.Create(user);
            return Ok(user);
        }
        [HttpPut]
        public ActionResult Update(User user) {
            userService.Update(user.Id, user);
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            userService.Delete(id);
            return Ok();
        }
    }
}
