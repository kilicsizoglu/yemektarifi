using Microsoft.AspNetCore.Mvc;

namespace Namespace;

[Route("api/lls")]
[ApiController]
public class llsControllers : Controller
{
    private YemekTarifiDbContext Context;
    public llsControllers(YemekTarifiDbContext _Context) {
        Context = _Context;
    }

    [HttpPost(Name = "Login")]
    [Route("Login")]
    public IActionResult Login([FromBody] LoginResponse response) {
        UsersTable? user = Context.usersTable.Where(u => u.Name == response.user.Name && 
                                                         u.Password == response.user.Password)
                                                         .FirstOrDefault();
        Guid Key = Guid.NewGuid();
        if (user != null) {
            Context.keysTable.Add(new ApiKeysTable { 
                Id = Guid.NewGuid(),
                UserId = user.Id,
                Key = Key
            });
            return Ok(Key);
        }
        return Ok("reject");
    }

    [HttpPost(Name = "Logout")]
    [Route("Logout")]
    public IActionResult Logout([FromBody] Guid key) {
        Context.keysTable.Remove(new ApiKeysTable {
            Key = key
        });
        return Ok("ok");
    }

    [HttpPost(Name = "SingUp")]
    [Route("SingUp")]
    public IActionResult SingUp([FromBody] LoginResponse response) {
        if (response.user != null) {
            Context.usersTable.Add(response.user);
        }
        return Ok("ok");
    }

}
