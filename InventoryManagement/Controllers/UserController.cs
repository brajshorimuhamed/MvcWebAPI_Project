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
    public class UserController : Controller
    {
        UserAPI _API = new UserAPI();

        public async Task<IActionResult> Index()
        {
            List<UserData> userData = new List<UserData>();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync("https://localhost:44322/api/user");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                userData = JsonConvert.DeserializeObject<List<UserData>>(result);
            }
            return View(userData);
        }

        public async Task<IActionResult> Details(int Id)
        {
            var userData = new UserData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync($"https://localhost:44322/api/user/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                userData = JsonConvert.DeserializeObject<UserData>(result);
            }

            return View(userData);
        }

        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(UserData userData)
        {
            HttpClient clientApi = _API.Initial();

            // HTTP Post
            var postApi = clientApi.PostAsJsonAsync<UserData>("https://localhost:44322/api/user", userData);
            postApi.Wait();

            var result = postApi.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // ModelState.AddModelError(string.Empty, "Error Registration. Please contact with administrator");

            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var userData = new UserData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.GetAsync($"https://localhost:44322/api/user/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                userData = JsonConvert.DeserializeObject<UserData>(result);
            }

            return View(userData);
        }

        [HttpPost]
        public IActionResult Edit(UserData userData)
        {
            HttpClient clientApi = _API.Initial();

            // HTTP Put
            var putApi = clientApi.PutAsJsonAsync<UserData>($"https://localhost:44322/api/user/{userData.Id}", userData);
            putApi.Wait();

            var result = putApi.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            // ModelState.AddModelError(string.Empty, "Error Registration. Please contact with administrator");

            return View();
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var userData = new UserData();
            HttpClient clientApi = _API.Initial();
            HttpResponseMessage res = await clientApi.DeleteAsync($"https://localhost:44322/api/user/{Id}");

            return RedirectToAction("Index");
        }
    }
}