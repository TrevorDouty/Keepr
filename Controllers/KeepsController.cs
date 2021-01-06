using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Services;
using CodeWorks.Auth0Provider;
using System.Threading.Tasks;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;

    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Keep>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]

    public ActionResult<Keep> GetOne(int id)
    {
      try
      {
        return Ok(_ks.GetOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> Create([FromBody] Keep keep)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        keep.CreatorId = userinfo.Id;
        Keep newKeep = _ks.Create(keep);
        newKeep.Creator = userinfo;
        return Ok(newKeep);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ks.Delete(id, userinfo.Id));
      }
      catch (System.Exception)
      {
        return BadRequest("Cannot Delete");
      }
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<Keep>> Edit(int id, [FromQuery] Keep editKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editKeep.Id = id;
        return Ok(_ks.Edit(editKeep, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpPut("{id}/keepcount")]
    [Authorize]

    public async Task<ActionResult<Keep>> EditKeepCount(int id, [FromQuery] Keep editKeep)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editKeep.Id = id;
        return Ok(_ks.EditKeepCount(editKeep, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}