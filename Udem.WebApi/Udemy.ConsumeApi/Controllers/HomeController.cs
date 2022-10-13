﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Udemy.ConsumeApi.Response;

namespace Udemy.ConsumeApi.Controllers
{
    public class HomeController:Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5000/api/products");
            if(responseMessage.StatusCode==System.Net.HttpStatusCode.OK)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
               var result= JsonConvert.DeserializeObject<List<ProductResponseModel>>(jsonData);
               return View(result);
            }else
            {
                return View(null);
            }
             
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductResponseModel model)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent content=new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5000/api/products", content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
            return View();
        }
        public async Task <IActionResult> Update(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5000/api/products/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ProductResponseModel>(jsonData);
                return View(data);
            }
            else
            {
                return View(null);
            }
        }
        [HttpPost]
        public async Task<IActionResult>Update(ProductResponseModel model)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5000/api/products",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }
        public async Task<IActionResult>Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5000/api/products/{id}");
            return RedirectToAction("Index");
          
        }

        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var client=_httpClientFactory.CreateClient();
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes=stream.ToArray(); 
            ByteArrayContent content = new ByteArrayContent(bytes);
            content.Headers.ContentType=new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(file.ContentType);
            MultipartFormDataContent formdata = new MultipartFormDataContent();
            formdata.Add(content,"formFile",file.FileName);
            await client.PostAsync("http://localhost:5000/api/products/upload", formdata);
            return RedirectToAction("Index");
        }
    }
}
