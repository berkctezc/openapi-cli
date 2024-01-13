namespace Library.Service;

public static class Helpers
{
    public static string CreateQueryString(object obj)
    {
        var properties = obj.GetType().GetProperties();
        var queryString = new StringBuilder();

        foreach (var property in properties)
        {
            var attributeName = (JsonPropertyNameAttribute) Attribute.GetCustomAttribute(property, typeof(JsonPropertyNameAttribute));

            var key = attributeName?.Name ?? property.Name;
            var value = property.GetValue(obj)?.ToString();

            if (value != null)
            {
                queryString.Append($"{key}={value}&");
            }
        }

        if (queryString.Length > 0)
            queryString.Length--; // Remove the last character

        return queryString.ToString();
    }

    public static async Task<bool> Download(string? fileName, string path, string fileUrl)
    {
        try
        {
            Directory.CreateDirectory(path);

            fileName ??= fileUrl.Split('/').LastOrDefault();

            using var client = new HttpClient();
            using var response = await client.GetAsync(fileUrl);
            await using var responseStream = await response.Content.ReadAsStreamAsync();

            await using var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create);
            await responseStream.CopyToAsync(fileStream);

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}