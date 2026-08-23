using Katebarik.Domain.ValueObjects.Records;

namespace Katebarik.Domain.ValueObjects;

public record RouteSummary
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public double DistanceMeters { get; init; }
    public double ElevationMeters { get; init; }
    public string? Type { get; init; }
    public DateTime CreateDate { get; init; }
    public DateTime? UpdateDate { get; init; }

    public static RouteSummary Create(
        string name,
        string type,
        DateTime start,
        DateTime end,
        DateTime create)
    {
        return new RouteSummary
        {
            Name = name,
            Type = type,
            StartDate = start,
            EndDate = end,
            CreateDate = create
        };
    }

    public static RouteSummary Create(
        string name,
        string description,
        DateTime startDate,
        DateTime endDate,
        double distance,
        double elevation,
        string type,
        DateTime create)
    {
        return new RouteSummary
        {
            Name = name,
            Description = description,
            Type = type,
            StartDate = startDate,
            EndDate = endDate,
            DistanceMeters = distance,
            ElevationMeters = elevation,
            CreateDate = create
        };
    }

    public static RouteSummary CopyWithRecords(RouteSummary summary, RouteRecords records)
    {
        return new RouteSummary
        {
            Name = summary.Name,
            Type = summary.Type,
            Description = summary.Description,
            StartDate = records.Values.First().Timestamp,
            EndDate = records.Values.Last().Timestamp,
            DistanceMeters = (double)records.Values.Last().DistanceMeters,
            ElevationMeters = CalculateElevation(records.Values),
        };
    }

    private static double CalculateElevation(IReadOnlyList<RecordData> records)
    {
        double elevation = 0.0;
        var lastAltitude = records[0].Coordinates.Altitude;
        for(int i = 1; i < records.Count; i++)
        {
            var currentAltitude = records[i].Coordinates.Altitude;
            float altDiff = (float)(currentAltitude - lastAltitude);
            lastAltitude = currentAltitude;
            elevation += altDiff > 0 ? altDiff : 0;
        }
        return elevation;
    }
}
