using System.Text.Json;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var seen = new HashSet<string>();

        foreach (var word in words)
        {
            string reversed = new string(new char[] { word[1], word[0] });
            if (word == reversed) continue;

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}");
            }
            else
            {
                seen.Add(word);
            }
        }

        return result.ToArray();
    }

    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();
                if (degrees.ContainsKey(degree))
                {
                    degrees[degree]++;
                }
                else
                {
                    degrees[degree] = 1;
                }
            }
        }

        return degrees;
    }

    public static bool IsAnagram(string word1, string word2)
    {
        string s1 = word1.Replace(" ", "").ToLower();
        string s2 = word2.Replace(" ", "").ToLower();

        if (s1.Length != s2.Length) return false;

        var counts = new Dictionary<char, int>();

        foreach (char c in s1)
        {
            if (counts.ContainsKey(c)) counts[c]++;
            else counts[c] = 1;
        }

        foreach (char c in s2)
        {
            if (!counts.ContainsKey(c)) return false;
            counts[c]--;
            if (counts[c] < 0) return false;
        }

        return true;
    }

    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();

        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        var response = client.Send(getRequestMessage);
        var json = new StreamReader(response.Content.ReadAsStream()).ReadToEnd();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var summary = new List<string>();

        if (featureCollection?.Features != null)
        {
            foreach (var feature in featureCollection.Features)
            {
                string place = feature.Properties.Place;
                // Use .GetValueOrDefault() or a null-coalescing operator to handle null magnitudes
                double mag = feature.Properties.Mag ?? 0.0;
                summary.Add($"{place} - Mag {mag}");
            }
        }

        return summary.ToArray();
    }
}
