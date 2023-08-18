using OprSimulator.Models;

namespace OprSimulator.Services;

public class ActivationService
{
	private readonly DiceService _diceService;

	public ActivationService(DiceService diceService)
	{
		this._diceService = diceService;
	}

	public void Attack(Unit attacker, Unit target)
	{
		var hits = new List<Hit>();

		foreach (var weapon in attacker.Weapons)
		{
			var dice = weapon.Attacks * attacker.Size;

			var hitRolls = Enumerable
				.Range(0, dice)
				.Select(_ => _diceService.Roll());

			// TODO: Add AP to hits... etc
			hits.AddRange(hitRolls.Where(x => x >= attacker.Quality).Select(x => new Hit()));
		}

		// Console.WriteLine($"Scored {hits.Count()} hits!");

		var defRolls = Enumerable
			.Range(0, hits.Count)
			.Select(_ => _diceService.Roll());

		var failedSaved = defRolls.Where(x => x < target.Defense).Count();

		// Console.WriteLine($"Target failed {failedSaved} saves");

		target.AssignDamage(failedSaved);

		// Console.WriteLine($"Target after damage... Size: {target.Size}, Wounds: {target.Wounds}");
	}
}
