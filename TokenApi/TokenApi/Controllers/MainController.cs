using Microsoft.AspNetCore.Mvc;

namespace tokenServer.Controllers;

[ApiController]
[Route("main")]
public class MainController : ControllerBase
{
    [HttpPost("connect")]
    public object Connect(
        [FromServices]CryptoService crypto,
        [FromBody]User user)
    {
        try{
            var token = crypto.GetToken(user);
            return new{
                Message = "Sucess",
                Token = token
            };
        }
        catch{
            return new{
                Message = "Fail"
            };
        }
    }

    [HttpPost("changename")]
    public object ChangeName(
        [FromServices]CryptoService crypto,
        [FromBody]string token
    )
    {
        User user = null;
        try{
            var token = paramenters.Token;
            user = crypto.Validate<User>(token);
        }
        catch
        {
            return new{
                Message = "Invalid Token"
            };
        }

        if (!user.IsAdm)
        {
            return new{
                Message = "Invalid Access Level"
            };
        }

        user.Name = parameters.NewName;
        var newToken = crypto.GetToken(user);
        return new{
            Message = "Success",
            Token = newToken
        };
    }
}