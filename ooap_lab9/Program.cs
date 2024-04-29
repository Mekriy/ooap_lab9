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
                Console.WriteLine("Unprocessable state of the order.");
                break;
        }
    }
    private void ShipOrder()
    {
        Console.WriteLine("Order is shipped.");
        State = State.Shipped;
    }
    private void InvoiceOrder()
    {
        Console.WriteLine("Order is invoiced.");
        State = State.Invoiced;
    }
}

internal static class Program
{
    private static void Main()
    {
        Order order = new Order();
        Console.WriteLine("Order state: " + order.State);
        order.ProcessOrder();
        Console.WriteLine("Order state: " + order.State);
        order.ProcessOrder(); 
        Console.WriteLine("Order state: " + order.State);
    }
}