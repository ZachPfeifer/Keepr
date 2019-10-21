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
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<Keep>> GetVaultKeep(int vaultId)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.GetVaultKeep(vaultId, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpGet("{id}")]
    // public ActionResult<Vault> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_vks.Get(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    // [HttpGet("user")]
    // public ActionResult<IEnumerable<Vault>> GetUserVaults()
    // {
    //   try
    //   {
    //     string userId = HttpContext.User.FindFirstValue("Id");
    //     return Ok(_vks.GetUsersVaults(userId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(newVaultKeep, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // [HttpPut("{id}")]
    // public ActionResult<Vault> Edit([FromBody] Vault newData, int id)
    // {
    //   try
    //   {
    //     newData.Id = id;
    //     return Ok(_vks.Edit(newData));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }

    [HttpDelete("{id}")]
    public ActionResult<string> RemoveKeepFromVault(int id)
    {
      try
      {
        return Ok(_vks.RemoveKeepFromVault(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
