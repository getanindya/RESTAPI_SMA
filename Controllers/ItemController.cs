using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTAPI_SMA.Models;

namespace RESTAPI_SMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        public ItemController(IItemRepository items)
        {
            RepoItems = items;
        }
        public IItemRepository RepoItems { get; set; }
        public IEnumerable<Item> Get()
        {
            return RepoItems.GetFirstFive() ;
        }
        [HttpGet("{start:int?}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAfterStart(int start)
        {
            if (start< 0)
            {
                return BadRequest();
            }
            return Ok(RepoItems.GetItemAfter(start));
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            RepoItems.Add(item);
            return CreatedAtRoute( new { id = item.Id }, item);
        }
    }
}