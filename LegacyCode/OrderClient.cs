using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegacyCode;

public class OrderClient
{
    private HttpClient _httpClient;

    public OrderClient(HttpClient httpClient)
    {
        _httpClient =  httpClient;
    }

    public OrderData? getOrderData(int orderId)
    {
        var url = $"https://codemanship.co.uk/api/orders.php?orderId={orderId}";

        var response = _httpClient
            .GetAsync(url)
            .GetAwaiter()
            .GetResult();

        response.EnsureSuccessStatusCode();

        var json = response.Content
            .ReadAsStringAsync()
            .GetAwaiter()
            .GetResult();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
            
        var order = JsonSerializer.Deserialize<OrderData>(json, options);

        if (order == null)
            throw new Exception("Failed to deserialize order");
        return order;
    }
}