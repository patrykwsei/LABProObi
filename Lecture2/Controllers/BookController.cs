using Lecture2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture2.Controllers
{
    // Przykładowy kontroler realizujący operacje CRUD 
    public class BookController : Controller
    {
        //tymczasowa forma przechowywania informacji o książkach
        private static Dictionary<int, Book> _books = new Dictionary<int, Book>()
        {
            {
                1, new Book()
                {
                    Id = 1,
                    Title = "Asp.Net in practice",
                    ISBN = "123456789",
                    Pages = 890,
                    Category = Category.Technology,
                    PublishingYear = 2020,
                }
            },
            {
                2, new Book()
                {
                    Id = 2,
                    Title = "Lord of the rings",
                    ISBN = "9878989123",
                    Pages = 2378,
                    Category = Category.Fantasy,
                    PublishingYear = 1954,
                }
            }
        };
        // Metoda zwraca listę książek z linkami do edycji, usuwania i szczegółow
        public ActionResult Index()
        {
            return View(_books.Values.ToList());
        }

        // Metoda zwraca widok ze szczegółami książki
        // w żądaniu (ścieżce) musi być zawarty identyfikator książki
        //np. book/details/5
        public ActionResult Details(int id)
        {
            if (!_books.ContainsKey(id))
            {
                return NotFound();
            }
            return View(_books[id]);
        }

        // Metoda zwraca widok formularza dodania nowej książki
        public ActionResult Create()
        {
            return View();
        }

        // Metoda odbiera dane z formularza dodania książki
        // w żądaniu oczekujemy paramtrów o nazwach zgodnych 
        // z właściwościami modelu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            if (ModelState.IsValid)
            {
                int index = _books.Max(b => b.Key) + 1;
                model.Id = index;
                _books.Add(model.Id, model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // Metoda zwraca formularz edycji książki
        // W żądaniu (ścieżce) musi się znaleźć identyfikator książki
        // np. book/edit/5
        public ActionResult Edit(int id)
        {
            if (!_books.ContainsKey(id))
            {
                return NotFound();
            }
            return View(_books[id]);
        }

        // Metoda odbiera dane z formularza edycji książki
        // w żądaniu oczekujemy paramtrów o nazwach zgodnych 
        // z właściwościami modelu
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            if (!_books.ContainsKey(id))
            {
                return NotFound();
            }
            _books[id] = book;
            return RedirectToAction(nameof(Index));
        }

        // Metoda zwraca formularz potwierdzenia usunięcia książki.
        // W żądaniu musi znaleźć się identyfikator książki w ścieżce np.
        // book/delete/5
        // Do widoku przekazywany jest model książki o podanym id,
        // choć sam formularz usunięcia zawiera tylko pole z id książki.
        // Pozostałe właściwości modelu służa do informowania
        // użytkownika o danych książki przeznaczonej do usunięcia.
        public ActionResult Delete(int id)
        {
            if (!_books.ContainsKey(id))
            {
                return NotFound();
            }
            return View(_books[id]);
        }

        // Metoda odbierająca dane z formularza potwierdzenia książki
        // Chociaż argumentem metody jest model książki
        // to w nim liczy się tylko właściwość Id.
        // Formularz potwierdzenia usunięcia
        // zawiera tylko ukryte pole z id książki
        // i tylko id jest przesyłane w żądaniu.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book model)
        {
            if (!_books.ContainsKey(model.Id))
            {
                return NotFound();
            }
            _books.Remove(model.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
