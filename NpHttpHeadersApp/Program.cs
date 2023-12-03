using System.Net.Http.Headers;
using System.Net.Http.Json;

HttpClient client = new();

string server = @"https://localhost:7017/";

// HEADERS

//client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
//client.DefaultRequestHeaders.Add("SecretCode", "12345");

//using var request = new HttpRequestMessage(HttpMethod.Get, server);
//request.Headers.Add("User-Agent", "Mozilla/5.0");
//request.Headers.Add("SecretCode", "555");

//using var response = await client.SendAsync(request);
//var responseText = await response.Content.ReadAsStringAsync();
//Console.WriteLine(responseText);

// POST REQUEST

//StringContent content = new("Hello world! Hello people!");

//using HttpRequestMessage request = new(HttpMethod.Post, server);
//request.Content = content;
//using HttpResponseMessage response = await client.SendAsync(request);

//using HttpResponseMessage response = await client.PostAsync(server, content);
//string text = await response.Content.ReadAsStringAsync();
//Console.WriteLine(text);



// POST JSON

Employee employee = new Employee() { Name = "Sammy", Age = 32 };

//JsonContent content = JsonContent.Create(employee);
//using var response = await client.PostAsync(server + "new", content);
//Employee? sam = await response.Content.ReadFromJsonAsync<Employee>();

using var response = await client.PostAsJsonAsync(server + "new", employee);

Employee? sam = await response.Content.ReadFromJsonAsync<Employee>();
Console.WriteLine($"Guid: {sam.Id}, Name: {sam.Name}, Age: {sam.Age}");


class Employee
{
    public string Id { set; get; } = "";
    public string Name { set; get; } = "";
    public int Age { set; get; }
}