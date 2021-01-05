using System.Collections.Generic;
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
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    private readonly VaultKeepsService _vks;

    public VaultsController(VaultsService vs, VaultKeepsService vks)
    {
      _vs = vs;
      _vks = vks;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        return Ok(_vs.Get());
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    [Authorize]

    public ActionResult<Vault> GetOne(int id)
    {
      try
      {
        return Ok(_vs.GetOne(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault Vault)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        Vault.CreatorId = userinfo.Id;
        Vault newVault = _vs.Create(Vault);
        newVault.Creator = userinfo;
        return Ok(newVault);
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]

    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_vs.Delete(id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/vaultkeeps")]
    public ActionResult<IEnumerable<Keep>> GetAction(int vaultId)
    {
      try
      {
        return Ok(_vks.GetKeepsByVaultId(vaultId));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}