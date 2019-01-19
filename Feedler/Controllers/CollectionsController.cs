using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Feedler.BLL.DTOs;
using Feedler.BLL.Services.FeedService.Concrete;
using Feedler.BLL.Services.FeedService.Contract;
using Feedler.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace Feedler.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private IMemoryCache _memoryCache;
        private IFeedsCollectionService _collectionService;

        public CollectionsController(IMemoryCache memoryCache, FeedlerContext context)
        {
            _memoryCache = memoryCache;
            _collectionService = new FeedsCollectionService(context);
        }

        [HttpGet]
        public async Task<IActionResult> Get() //returns all ids of created collections, not required
        {
            return Ok(); //200 response 
        }

        [HttpGet("{collectionId}")]
        public async Task<IActionResult> Get(int id) // returns one collection, parses all urls in the collection
        {
            return Ok(); //200 response
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedsCollectionDto collection) //creates collection, must return id
        {
            int collectionId = _collectionService.CreateCollection(collection.Name);
            return CreatedAtAction("Get", new { id = collectionId }); ; //must be a 201 response
        }

        [HttpPut("{collectionId}")]
        public async Task<IActionResult> Add(int id) //adds url to collection
        {
            //if (id != collection.Id) return BadRequest();


            return NoContent(); //204 response
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IActionResult>> Delete(int id) //deletes the collection, not required
        {
            return NoContent(); //204 response
        }
    }
}