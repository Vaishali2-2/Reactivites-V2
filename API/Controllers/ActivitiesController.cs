using System;
using Domain;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

public class ActivitiesController(AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Domain.Activities>>> GetActivities()
    {
        return await context.Activities.ToListAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Domain.Activities>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        if (activity == null) return NotFound();

        return activity;
    }

}
