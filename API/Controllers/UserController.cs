﻿using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UserController: ControllerBase
{
    private readonly DataContext _context;
    public UserController(DataContext context)
    {
        this._context=context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var Users=await _context.Users.ToListAsync();
        return Users;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
            return await _context.Users.FindAsync(id);
    }
}
