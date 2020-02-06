using System;
using System.Security.Claims;
using CSharp_Blogs.Models;
using CSharp_Blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Blogs.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class TeamsController : ControllerBase
  {
    private readonly TeamsService _ps;
    public TeamsController(TeamsService ps)
    {
      _ps = ps;
    }

    [HttpGet("{id}")]
    public ActionResult<Team> GetById(int id)
    {
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }

      //make another get for another thing

    }
    [HttpPost]
    [Authorize]
    public ActionResult<Team> Create([FromBody] Team newData)
    {
      try
      {
        newData.CreatorId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        return Ok(_ps.Create(newData));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]
    [Authorize]
    public ActionResult<Team> Edit([FromBody] Team update, int id)
    {
      try
      {
        update.Id = id;
        update.CreatorId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ps.Edit(update));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        var creatorId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_ps.Delete(creatorId, id));

      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}