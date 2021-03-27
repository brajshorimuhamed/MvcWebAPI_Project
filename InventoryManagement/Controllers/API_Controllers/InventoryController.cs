using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Entities._DTO;
using InventoryManagement.Models.Services_BL.Inventories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers.API_Controllers
{
    [Route("api/inventory")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;

        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }

        // GET: api/Inventory
        [HttpGet]
        public List<InventoryData> Get()
        {
            return _inventoryService.GetInventories();
        }

        // GET: api/Inventory/5
        [HttpGet("{Id}", Name = "GetInventory")]
        public InventoryData GetInventory(int Id)
        {
            return _inventoryService.GetInventoryById(Id);
        }

        // POST: api/Inventory
        [HttpPost]
        public IActionResult PostInventory([FromBody] InventorySubmissionModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid model");

            _inventoryService.AddInventory(model);

            return Ok();
        }

        // PUT: api/Inventory/5
        [HttpPut("{Id}")]
        public IActionResult PutInventory(int Id, [FromBody] InventoryUpdateSubmissionModel inventoryData)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not valid model");

            var inventoryId = _inventoryService.GetInventoryById(Id);
            if (inventoryId != null)
            {
                _inventoryService.UpdateInventory(inventoryData);

                return Ok();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{Id}")]
        public IActionResult DeleteInventory(int Id)
        {
            var inventory = _inventoryService.GetInventoryById(Id);

            if (inventory == null)
            {
                return NotFound();
            }

            _inventoryService.DeleteInventory(inventory.Id);

            return NoContent();
        }
    }
}
