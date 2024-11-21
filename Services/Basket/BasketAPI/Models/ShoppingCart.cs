namespace BasketAPI.Models;

public class ShoppingCart
{
    //string? vs default! - 1-can be null but need to check in code / it okay to be null at the begining but after that cannot be null
    public string UserName { get; set; } = default!;
    public List<ShoppingCartItem> Items { get; set; } = new();

    public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

    public ShoppingCart(string UserName)
    {
        this.UserName = UserName;
    }
    public ShoppingCart()
    {        
    }
}
