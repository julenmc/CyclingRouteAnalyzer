using Katebarik.Domain.ValueObjects;
using Katebarik.Domain.ValueObjects.Common;
using Katebarik.Domain.ValueObjects.Records;

namespace Katebarik.Domain.Entities;

public class Route
{
    public FilePath Path { get; private set; }
    public RouteSummary Summary { get; private set; }
    public RouteRecords? Records { get; private set; }

    private Route()
    {

    }

    private Route(
        FilePath path,
        RouteSummary data)
    {
        Path = path;
        Summary = data;
    }

    public static Route Create(
        FilePath filePath,
        RouteSummary data)
        => new Route(
            filePath,
            data);

    public static Route Load(
        FilePath filePath,
        RouteSummary summary)
        => new Route(
            filePath,
            summary);

    public void UpdateSummary(RouteSummary summary)
    {
        ArgumentNullException.ThrowIfNull(summary);

        Summary = summary;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException(nameof(name), "Name can't be empty");
            
        Summary = Summary with { Name = name };
    }

    public void UpdateDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
            throw new ArgumentNullException(nameof(description), "Description can't be empty");

        Summary = Summary with { Description = description };
    }

    public void AddRecords(RouteRecords records)
    {
        ArgumentNullException.ThrowIfNull(records);

        if (records.Values.Count == 0)
            throw new ArgumentException("Cannot load empty records");

        Records = records;
    }
}
