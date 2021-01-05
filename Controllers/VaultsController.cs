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

    public async Task<ActionResult<IEnumerable<Vault>>> Get()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vs.Get(userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<Vault>> GetOne(int id)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_vs.GetOne(id, userInfo.Id));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> Create([FromBody] Vault vault)
    {
      try
      {
        Profile userinfo = await HttpContext.GetUserInfoAsync<Profile>();
        vault.CreatorId = userinfo.Id;
        Vault newVault = _vs.Create(vault);
        newVault.Creator = userinfo;
        return Ok(newVault);
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
        return Ok(_vs.Delete(id, userinfo.Id));
      }
      catch (System.Exception)
      {
        return BadRequest("Cannot Delete");
      }
    }

    [HttpPut("{id}")]
    [Authorize]

    public async Task<ActionResult<Vault>> Edit(int id, [FromBody] Vault editVault)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        editVault.Id = id;
        return Ok(_vs.Edit(editVault, userInfo.Id));
      }
      catch (System.Exception)
      {

        throw;
      }
    }

    [HttpGet("{vaultId}/keeps")]
    [Authorize]

    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
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