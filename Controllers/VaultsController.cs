using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Keepr.Models;
using Keepr.Services;
using System.Security.Claims;

namespace Keepr.Controllers
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
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_vs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("user")]
    public ActionResult<IEnumerable<Vault>> GetUserVaults()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.GetUsersVaults(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault newVault)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    [HttpPut("{id}")]
    public ActionResult<Vault> Edit([FromBody] Vault newData, int id)
    {
      try
      {
        newData.Id = id;
        return Ok(_vs.Edit(newData));
      }
      catch (Exception e)
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
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
