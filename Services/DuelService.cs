using OprSimulator.Models;

namespace OprSimulator.Services;

public class DuelService
{
	private ActivationService _activationService;

	public DuelService(ActivationService activationService)
	{
		_activationService = activationService;
	}

	public void Duel(Unit originalA, Unit originalB)
	{
		var results = new List<Result>();

		for (int i = 1; i < 10_000; i++)
		{
			var a = originalA.Clone();
			var b = originalB.Clone();

			var result = new Result();
			int j = i % 2 == 0 ? 1 : 2;
			while (a.Size > 0 && b.Size > 0)
			{
				bool even = j++ % 2 == 0;
				var attacker = even ? a : b;
				var defender = even ? b : a;

				result.AttacksToKill++;

				_activationService.Attack(attacker, defender);
			}

			result.Winner = a.Size > 0 ? a : b;
			results.Add(result);

			Console.WriteLine();
		}

		decimal total = results.Count();

		foreach (var group in results.GroupBy(x => new { x.Winner.Name }))
		{
			decimal count = group.Count();
			decimal prc = count / total * 100m;
			var roundsToKill = results.Average(x => x.AttacksToKill / 2m);
			Console.WriteLine(group.Key + $" won {prc:0.00}% - avg {roundsToKill:0.000} rounds");
		}
	}
}
