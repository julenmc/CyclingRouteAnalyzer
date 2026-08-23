namespace Katebarik.Domain.ValueObjects.Records;

public record RecordData
{
    public required DateTime Timestamp { get; init; }
    public required Coordinates Coordinates { get; init; }
    public required float DistanceMeters { get; init; }
    public required SmoothedAltitude SmoothedAltitude { get; init; }
}
