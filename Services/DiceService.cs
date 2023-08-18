namespace OprSimulator.Services;

public class DiceService
{
	private Random _rnd = new Random();

	public int Roll(int d = 6)
	{
		return _rnd.Next(1, 7);
	}
}
