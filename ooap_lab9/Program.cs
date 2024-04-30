public interface IOrderState
{
    string CreateNewOrder();
    string ShipOrder();
    string InvoiceOrder();
}

public interface IOrder
{
    void CreateNewOrder();
    void ShipOrder();
    void InvoiceOrder();
    void SetState(IOrderState state);
    IOrderState CreateNewOrderState();
    IOrderState ShipOrderState();
    IOrderState InvoiceOrderState();
}
public class Order : IOrder
{
    private IOrderState _newOrderState;
    private IOrderState _shippedState;
    private IOrderState _invoicedState;
    private IOrderState _state;
    
    public Order()
    {
        _newOrderState = new CreateNewOrderState(this);
        _shippedState = new ShipOrderState(this);
        _invoicedState = new InvoiceOrderState(this);
        _state = _newOrderState;
    }

    public void SetState(IOrderState state)
    {
        _state = state;
    }
    public void CreateNewOrder()
    {
        Console.WriteLine(_state.CreateNewOrder());
    }

    public void ShipOrder()
    {
        Console.WriteLine(_state.ShipOrder());
    }

    public void InvoiceOrder()
    {
        Console.WriteLine(_state.InvoiceOrder());
    }

    public IOrderState CreateNewOrderState()
    {
        return _newOrderState;
    }

    public IOrderState ShipOrderState()
    {
        return _shippedState;
    }

    public IOrderState InvoiceOrderState()
    {
        return _invoicedState;
    }
    
}
public class CreateNewOrderState : IOrderState
{
    private Order _order;

    public CreateNewOrderState(Order order)
    {
        _order = order;
    }
    public string CreateNewOrder()
    {
        _order.SetState(_order.ShipOrderState());
        return "Order was created!";
    }

    public string ShipOrder()
    {
        return "You have to create order first";
    }

    public string InvoiceOrder()
    {
        return "You have to create order first";
    }
}
public class ShipOrderState : IOrderState
{
    private Order _order;

    public ShipOrderState(Order order)
    {
        _order = order;
    }
    public string CreateNewOrder()
    {
        return "You've already created order";
    }

    public string ShipOrder()
    {
        _order.SetState(_order.InvoiceOrderState());
        return "Shipped order!";
    }

    public string InvoiceOrder()
    {
        return "You haven't shipped order yet!";
    }
}
public class InvoiceOrderState : IOrderState
{
    private Order _order;

    public InvoiceOrderState(Order order)
    {
        _order = order;
    }

    public string CreateNewOrder()
    {
        return "You've already created order!";
    }

    public string ShipOrder()
    {
        return "You've already shipped order. Please invoice it!";
    }

    public string InvoiceOrder()
    {
        _order.SetState(_order.InvoiceOrderState());
        return "You've invoiced order!";
    }
}
internal static class Program
{
    private static void Main()
    {
        Order order = new Order();
        order.CreateNewOrder();
        order.ShipOrder();
        order.InvoiceOrder();
    }
}