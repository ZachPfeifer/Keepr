using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Keepr.Models;
using Keepr.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
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
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    // [HttpGet("{id}/shoes")]
    // public ActionResult<Order> GetShoes(int id)
    // {
    //   try
    //   {
    //     return Ok(_ss.GetShoes(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetUserKeeps()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.GetUsersKeeps(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // [HttpPost]
    // public ActionResult<Order> Create([FromBody] Order newOrder)
    // {
    //   try
    //   {
    //     newOrder.UserId = HttpContext.User.FindFirstValue("Id");
    //     return Ok(_ss.Create(newOrder));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newKeep, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep newData, int id)
    {
      try
      {
        newData.Id = id;
        return Ok(_ks.Edit(newData));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]//FIXME
    public ActionResult<Keep> UpdateView([FromBody] Keep viewCount, int id)
    {
      try
      {
        viewCount.Id = id;
        return Ok(_ks.ViewCount(viewCount));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // public Order Edit(Order newData)
    // {
    //   Order order = _repo.Get(newData.Id);
    //   if (order == null) { throw new Exception("Invalid Id Homie"); }
    //   order.UserId = newData.UserId;
    //   _repo.Edit(order);
    //   return order;
    // }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}
