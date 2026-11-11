
using System.Collections.Generic;

/// <summary>
/// Represents the complete earthquake JSON collection.
/// </summary>
public class FeatureCollection
{
    public string? Type { get; set; }

    public List<EarthquakeFeature>? Features { get; set; }
}

/// <summary>
/// Represents an individual earthquake record.
/// </summary>
public class EarthquakeFeature
{
    public string? Type { get; set; }

    public EarthquakeProperties? Properties { get; set; }
}

/// <summary>
/// Contains the earthquake location and magnitude.
/// </summary>
public class EarthquakeProperties
{
    public double? Mag { get; set; }

    public string? Place { get; set; }
}
