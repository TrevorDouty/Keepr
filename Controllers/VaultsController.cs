using System.Collections.Generic;
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

    public VaultsController(VaultsService vs)
    {
      _vs = vs;
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
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      try
      {
        return Ok(_vs.Create(vault));
      }
      catch (System.Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}