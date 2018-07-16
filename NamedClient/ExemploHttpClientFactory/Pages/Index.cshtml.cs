using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ExemploHttpClientFactory.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet(
            [FromServices]IHttpClientFactory httpClientFactory)
        {
            DateTime dataBase = DateTime.Now.Date.AddDays(
                new Random().Next(0, 7) * -1);

            var client = httpClientFactory.CreateClient("NASA_API");

            var response = client.GetAsync(
                client.BaseAddress +
                $"&date={dataBase.ToString("yyyy-MM-dd")}").Result;

            response.EnsureSuccessStatusCode();
            string conteudo =
                response.Content.ReadAsStringAsync().Result;
            dynamic resultado =
                JsonConvert.DeserializeObject(conteudo);

            ImagemNASA imagem = new ImagemNASA();
            imagem.Data = dataBase;
            imagem.Titulo = resultado.title;
            imagem.Descricao = resultado.explanation;
            imagem.Url = resultado.url;
            imagem.MediaType = resultado.media_type;

            TempData["ImagemNASA"] = imagem;
        }       
    }
}