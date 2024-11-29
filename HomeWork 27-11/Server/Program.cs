using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

public class Order
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
}

public class Server
{
    private static List<Order> orders = new List<Order>();

    public static void Main()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Server started at http://localhost:8080/");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (request.HttpMethod == "POST" && request.Url.AbsolutePath == "/order")
            {
                using (StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                {
                    string requestData = reader.ReadToEnd();
                    Order order = ParseOrder(requestData); // Парсим строку в объект Order
                    orders.Add(order);

                    Console.WriteLine($"Order received: {order.Id}, {order.ProductName}, {order.Quantity}, {order.OrderDate}");

                    string responseMessage = "Order received and saved.";
                    byte[] responseBytes = Encoding.UTF8.GetBytes(responseMessage);
                    response.OutputStream.Write(responseBytes, 0, responseBytes.Length);
                }
            }

            response.Close();
        }
    }

    private static Order ParseOrder(string data)
    {
        string[] parts = data.Split('|');
        return new Order
        {
            Id = int.Parse(parts[0]),
            ProductName = parts[1],
            Quantity = int.Parse(parts[2]),
            OrderDate = DateTime.Parse(parts[3])
        };
    }
}
