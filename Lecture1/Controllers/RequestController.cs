using Microsoft.AspNetCore.Mvc;

namespace Lecture1.Controllers;

public class RequestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public string Info()
    {
        string[] arr =
        [
            Request.Path.ToString(),
            Request.QueryString.ToString(),
            Request.Method,
            Request.Host.ToString(),
            Request.Scheme,
            Request.ContentType??"brak",
            Request.Headers["User-Agent"],
        ];
        return string.Join(", ", arr);
    }
}