using Microsoft.AspNetCore.Mvc;
using backend.Model;
using System.Linq;
namespace backend.Controllers;

[ApiController]
[Route("user")]
public class UserController: ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> UserRegister([FromBody]Usuario user)
    {
        BdccodexContext context = new BdccodexContext();
        List<string> errors = new List<string>();
        var userInDB = context.Usuarios.FirstOrDefault(u => u.Nome == user.Nome);
        if(userInDB != null)
            return BadRequest("Usuario existente.");
        
        if(user.Nome == null)
            errors.Add("Nome obrigatório.");
        if(user.Email == null)
            errors.Add("Email obrigatório.");
        if(user.Senha == null)
            errors.Add("Senha obrigatório.");
        if(errors.Count() > 0)
            return BadRequest(errors);        
        try
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok("Dados salvos com sucesso.");
        }
        catch
        {
            return BadRequest("Erro no servidor.");
        }
    }

    public async Task<IActionResult> UserLogin(Usuario user)
    {
        BdccodexContext context = new BdccodexContext();
        var userInDatabase = context.Usuarios.FirstOrDefault(u => u.Nome == user.Nome);
        if(userInDatabase == null)
            return BadRequest("usuario inexistnte.");
        if(user.Email != userInDatabase.Email)
            return BadRequest("Email errado.");
        if(user.Nome == "Manoelgome")
            Response.Redirect(@"/manoelgome");  
            return Ok();
    }
}
