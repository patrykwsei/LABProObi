using System;
using System.Collections.Generic;

namespace Lab07.models.movies;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryIsoCode { get; set; }

    public string? CountryName { get; set; }
}
