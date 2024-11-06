﻿using AccountProvider.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AccountProvider.Functions;

public class GetOneUser
{
    private readonly ILogger<GetOneUser> _logger;
    private readonly IUserService _userService;

    public GetOneUser (ILogger<GetOneUser> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
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

            var user = await _userService.GetUserAsync(u => u.Id == userId);

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
            
        }
        return new StatusCodeResult(500);
    }
}

