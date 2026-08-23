namespace Katebarik.Domain.ValueObjects.Records;

public record SmoothedAltitude
{
    public double Altitude { get; init; }
    public float Slope { get; init; }
}
