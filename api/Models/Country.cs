using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Country
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public required string Name { get; set; }

        public string? IsoA2 { get; set; }

        public string? IsoA3 { get; set; }

        public Geometry WkbGeometry { get; set; } = null!; // MultiPolygon geometry type

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
