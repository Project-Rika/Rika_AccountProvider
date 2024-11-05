using AccountProvider.Interfaces;
using AccountProvider.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AccountProvider.Functions;

public class GetOneUser
{
    private readonly ILogger<GetOneUser> _logger;
    private readonly UserRepository _repositry;

    public GetOneUser (ILogger<GetOneUser> logger, UserRepository repositry)
    {
        _logger = logger;
        _repositry = repositry;
    }

    [Function("GetOneUserAsync")]
    public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        try
        {
            string userId = req.Query["UserId"];

            if (string.IsNullOrEmpty(userId))
            {
                return new BadRequestObjectResult("UserId is required.");
            }

            var user = await _repositry.GetUserAsync(u => u.Id == userId);

            if (user == null)
            {
                return new NotFoundObjectResult("User not found.");
            }
            else
            {
                return new OkObjectResult(user);
            }
           
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting User");
            return new BadRequestObjectResult("Error::" + ex.Message);
        }
    }
}

