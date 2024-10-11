
namespace EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var electronicsOrder = new ElectronicsOrder
            {
                OrderNumber = 1,
                CustomerName = "Иван Иванов",
                DeviceType = "Телефон",
                Items = {new OrderItem { ProductName = "iPhone 14", Quantity = 1, Price = 80000 }}
            };

            var furnitureOrder = new FurnitureOrder
            {
                OrderNumber = 2,
                CustomerName = "Петр Петров",
                FurnitureType = "Диван",
                Items = {new OrderItem { ProductName = "Диван кожаный", Quantity = 1, Price = 50000 }}
            };

            var clothingOrder = new ClothingOrder
            {
                OrderNumber = 3,
                CustomerName = "Мария Иванова",
                Size = "M",
                Items = {new OrderItem { ProductName = "Платье", Quantity = 2, Price = 3000 }}
            };

            var orders = new List<Order> { electronicsOrder, furnitureOrder, clothingOrder };

            foreach (var order in orders)
            {
                order.PrintOrder();
                Console.WriteLine();
            }
        }
    }

    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public double CalculateTotal()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }

        public void PrintOrder()
        {
            Console.WriteLine($"Номер заказа: {OrderNumber}");
            Console.WriteLine($"Имя клиента: {CustomerName}");
            Console.WriteLine("Товары в заказе:");
            foreach (var item in Items)
            {
                Console.WriteLine($" - {item.ProductName}: {item.Quantity} шт. по {item.Price} руб.");
            }
            Console.WriteLine($"Итоговая стоимость: {CalculateTotal()} руб.");
        }
    }

    public class ElectronicsOrder : Order
    {
        public string DeviceType { get; set; }
    }

    public class FurnitureOrder : Order
    {
        public string FurnitureType { get; set; }
    }

    public class ClothingOrder : Order
    {
        public string Size { get; set; }
    }

    public class OrderItem
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
