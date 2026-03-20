using System.Collections.Generic;

// Classes required for Problem 5 JSON Deserialization
public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    // Changed to double? (nullable) to handle cases where the USGS
    // sends a "null" value for magnitude.
    public double? Mag { get; set; }
    public string Place { get; set; }
}
