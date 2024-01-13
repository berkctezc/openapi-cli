using System.Collections.Specialized;
using System.Reflection;
using System.Web;

namespace Library.Service;

public static class Helpers
{
    public static string ConvertToQueryString(object requestObject)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);

        AddToQueryString(query, requestObject);

        return query.ToString();
    }

    private static void AddToQueryString(NameValueCollection query, object value)
    {
        if (value is null) return;

        var keyName = string.Empty;

        var propertyInfo = value.GetType().GetProperty("JsonPropertyName");
        var jsonPropertyAttribute = propertyInfo?.GetCustomAttribute<JsonPropertyNameAttribute>();
        if (jsonPropertyAttribute != null)
        {
            keyName = jsonPropertyAttribute.Name;
        }

        if (value is string or int or decimal or bool)
        {
            query.Add(keyName, value.ToString());
            return;
        }

        var properties = value.GetType().GetProperties();
        foreach (var property in properties)
        {
            var propertyValue = property.GetValue(value);
            AddToQueryString(query, propertyValue);
        }
    }
}