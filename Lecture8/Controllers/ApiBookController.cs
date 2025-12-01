using Microsoft.AspNetCore.Mvc;

namespace Lecture8.Controllers;

[ApiController]
[Route("api/v1/books")]
public class ApiBookController : ControllerBase
{
    static List<Book> _list = new List<Book>()
    {
        new Book()
        {
            Id = 1,
            Author = "Joshua Bloch",
            Title = "Effective Java#"
        },
        new Book()
        {
            Id = 2,
            Author = "Robert Martin",
            Title = "Clean Code"
        },
        new Book()
        {
            Id = 3,
            Author = "Martin Fowler",
            Title = "Refactoring"
        }
    };

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(
            _list
        );
    }

    [HttpGet("{id}")]
    public ActionResult<Book> GetById(int id)
    {
        var obj = _list.FirstOrDefault(x => x.Id == id);
        if (obj is null)
        {
            return NotFound();
        }

        return Ok(obj);
    }

    [HttpPost]
    public IActionResult Create(LinkGenerator generator, Book model)
    {
        model.Id = _list.Max(x => x.Id) + 1;
        _list.Add(model);
        var link = generator.GetUriByRouteValues(
            HttpContext,
            nameof(GetById),
            new { id = model.Id }
        );
        return Created(link, model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Book? obj = _list.FirstOrDefault(x => x.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        else
        {
            _list.Remove(obj);
            return Ok();
        }
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Book model)
    {
        if (id != model.Id)
        {
            return BadRequest();
        }

        Book? obj = _list.FirstOrDefault(x => x.Id == id);
        if (obj is null)
        {
            return NotFound();
        }
        else
        {
            _list.Remove(obj);
            _list.Add(model);
            return Ok(model);
        }
    }
}