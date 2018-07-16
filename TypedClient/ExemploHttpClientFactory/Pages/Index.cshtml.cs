using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ExemploHttpClientFactory.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet([FromServices]APINasaClient client)
        {
            TempData["ImagemNASA"] = client.ObterDadosImagem();
        }
    }
}