using Lab07.models.movies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;

namespace Lab07.Controllers;

[ApiController]
public class ApiCompaniesController(MoviesContext context) : ControllerBase
{
    [HttpGet("/api/companies")]
    public IActionResult GetCompanies(string filter)
    {
        return Ok(
            context
                .ProductionCompanies
                .Where(c => c.CompanyName.Contains(filter))
                .ToList()
        );
    }
}