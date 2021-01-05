using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    private readonly VaultsService _vs;

    public VaultKeepsController(VaultKeepsService vks, VaultsService vs)
    {
      _vks = vks;
      _vs = vs;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeep)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        vaultKeep.CreatorId = userinfo.Id;
        return Ok(_vks.Create(vaultKeep));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]

    public async Task<ActionResult<string>> Delete(int id)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vks.Delete(id, userinfo.Id));
      }
      catch (System.Exception)
      {
        return BadRequest("Cannot Delete");
      }
    }

  }
}