using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InventoryManagement.Models.Entities;
using InventoryManagement.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventoryManagement.Controllers
{
    public class InventoryController : Controller
    {
        InventoryAPI _API = new InventoryAPI();

        public async Task<IActionResult> Index()
        {
            List<InventoryData> inventoryData = new List<InventoryData>();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync("https://localhost:44322/api/inventory");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                inventoryData = JsonConvert.DeserializeObject<List<InventoryData>>(result);
            }

            return View(inventoryData);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var inventoryData = new InventoryData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync($"https://localhost:44322/api/inventory/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                inventoryData = JsonConvert.DeserializeObject<InventoryData>(result);
            }

            return View(inventoryData);
        }

        public IActionResult AddInventory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddInventory(InventoryData inventoryData)
        {
            HttpClient clientApi = _API.Initial();

            // HTTP Post
            var postApi = clientApi.PostAsJsonAsync<InventoryData>("https://localhost:44322/api/inventory", inventoryData);
            postApi.Wait();

            var result = postApi.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var inventoryData = new InventoryData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync($"https://localhost:44322/api/inventory/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                inventoryData = JsonConvert.DeserializeObject<InventoryData>(result);
            }

            return View(inventoryData);
        }

        [HttpPost]
        public IActionResult Edit(InventoryData inventoryData)
        {
            HttpClient clientApi = _API.Initial();

            // HTTP Put
            var putApi = clientApi.PutAsJsonAsync<InventoryData>($"https://localhost:44322/api/inventory/{inventoryData.Id}", inventoryData);
            putApi.Wait();

            var result = putApi.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var inventoryData = new InventoryData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.DeleteAsync($"https://localhost:44322/api/inventory/{Id}");

            return RedirectToAction("Index");
        }
    }
}