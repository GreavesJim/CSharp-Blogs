using System;
using CSharp_Blogs.Models;
using CSharp_Blogs.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Blogs.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class PlayersController : ControllerBase
  {
    private readonly PlayersService _ps;
    public PlayersController(PlayersService ps)
    {
      _ps = ps;
    }

    [HttpGet("{id}")]
    public ActionResult<Player> GetById(int id)
    {
      try
      {
        return Ok(_ps.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e.Message);
      }
    }
  }
}