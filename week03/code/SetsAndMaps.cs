
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // Problem 1: Find pairs of words that are reverses of each other.
    public static string[] FindPairs(string[] words)
    {
        HashSet<int> wordSet = new HashSet<int>();

        foreach (string word in words)
        {
            int key = (word[0] << 16) | word[1];
            wordSet.Add(key);
        }

        List<string> pairs = new List<string>();

        foreach (int key in wordSet)
        {
            char first = (char)(key >> 16);
            char second = (char)(key & 0xFFFF);

            if (first == second)
                continue;

            int reverseKey = (second << 16) | first;

            if (wordSet.Contains(reverseKey) && key < reverseKey)
            {
                pairs.Add($"{first}{second} & {second}{first}");
            }
        }

        return pairs.ToArray();
    }

    // Problem 2: Count the degrees in the fourth column of the census file.
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        Dictionary<string, int> degrees = new Dictionary<string, int>();

        // Do not skip the first line because it contains actual data.
        foreach (string line in File.ReadLines(filename))
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] fields = line.Split(',');

            if (fields.Length < 4)
                continue;

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

        return degrees;
    }

    // Problem 3: Check whether two words are anagrams.
    // Ignore spaces and capitalization.
    public static bool IsAnagram(string word1, string word2)
    {
        string first = word1.Replace(" ", "").ToLowerInvariant();
        string second = word2.Replace(" ", "").ToLowerInvariant();

        if (first.Length != second.Length)
            return false;

        Dictionary<char, int> letterCounts =
            new Dictionary<char, int>();

        foreach (char letter in first)
        {
            if (letterCounts.ContainsKey(letter))
            {
                letterCounts[letter]++;
            }
            else
            {
                letterCounts[letter] = 1;
            }
        }

        foreach (char letter in second)
        {
            if (!letterCounts.ContainsKey(letter))
                return false;

            letterCounts[letter]--;

            if (letterCounts[letter] < 0)
                return false;
        }

        return true;
    }

    // Problem 5: Retrieve and summarize daily earthquake information.
    public static string[] EarthquakeDailySummary()
    {
        using HttpClient client = new HttpClient();

        string url =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        string response =
            client.GetStringAsync(url).GetAwaiter().GetResult();

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        FeatureCollection? collection =
            JsonSerializer.Deserialize<FeatureCollection>(response, options);

        if (collection?.Features == null)
            return Array.Empty<string>();

        List<string> summaries = new List<string>();

        foreach (EarthquakeFeature feature in collection.Features)
        {
            if (feature.Properties != null)
            {
                summaries.Add(
                    $"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return summaries.ToArray();
    }
}
