public enum State
{
    NewOrder,
    Shipped,
    Invoiced
}
public class Order
{
    public State State { get; private set; }

    public Order()
    {
        State = State.NewOrder; 
    }
    public void ProcessOrder()
    {
        switch (State)
        {
            case State.NewOrder:
                ShipOrder();
                break;
            case State.Shipped:
                InvoiceOrder(); 
                break;
            default:
                Console.WriteLine("Недопустимий перехід стану.");
                break;
        }
    }
    private void ShipOrder()
    {
        Console.WriteLine("Замовлення відправлено.");
        State = State.Shipped;
    }
    private void InvoiceOrder()
    {
        Console.WriteLine("Замовлення оплачено.");
        State = State.Invoiced;
    }
}

internal static class Program
{
    private static void Main()
    {
        Order order = new Order();
        Console.WriteLine("Початковий стан замовлення: " + order.State);
        order.ProcessOrder();
        Console.WriteLine("Поточний стан замовлення: " + order.State);
        order.ProcessOrder(); 
        Console.WriteLine("Поточний стан замовлення: " + order.State);
    }
}