using BuildingBlock.Exceptions;

namespace BaseketAPI.Exceptions;

public class BasketNotFoundException : NotFoundException
{
	public BasketNotFoundException(string userName): base("Basket",userName)
	{
	}
}
