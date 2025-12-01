using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

public class Book
{
    [ValidateNever]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}