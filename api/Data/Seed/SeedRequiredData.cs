using api.Models;
using api.Data;
using CsvHelper;
using System.Globalization;
using NetTopologySuite.IO;
using NetTopologySuite.Geometries;

public class SeedRequiredData
{
    private readonly ApplicationDBContext _context;

    public SeedRequiredData(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        if (!_context.Countries.Any())
        {
            var countries = GetCountriesFromCsv(Path.Combine("Data", "CSVSchema", "countries.csv"));
            await _context.Countries.AddRangeAsync(countries);
            await _context.SaveChangesAsync();
        }

    }

    private static List<Country> GetCountriesFromCsv(string csvFilePath)
    {
        using var reader = new StreamReader(csvFilePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var countries = new List<Country>();
        csv.Read();
        csv.ReadHeader();
        while (csv.Read())
        {
            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = csv.GetField<string>("name")!,
                IsoA2 = csv.GetField<string?>("iso_a2"),
                IsoA3 = csv.GetField<string?>("iso_a3"),
                WkbGeometry = (new WKBReader().Read(csv.GetField<byte[]>("wkb_geometry")) as MultiPolygon)!, // Convert WKB to Geometry
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            countries.Add(country);
        }
        return countries;
    }
}
