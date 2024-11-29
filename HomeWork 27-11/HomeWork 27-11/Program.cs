using System;
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

public class Client
{
    public static void Main()
    {
        Order order = new Order
        {
            Id = 1,
            ProductName = "Laptop",
            Quantity = 2,
            OrderDate = DateTime.Now
        };

        string orderData = $"{order.Id}|{order.ProductName}|{order.Quantity}|{order.OrderDate}";

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8080/order");
        request.Method = "POST";
        request.ContentType = "text/plain";

        using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
        {
            writer.Write(orderData);
        }

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            string responseMessage = reader.ReadToEnd();
            Console.WriteLine("Server response: " + responseMessage);
        }
    }
}
