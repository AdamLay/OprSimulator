// See https://aka.ms/new-console-template for more information
using OprSimulator.Models;
using OprSimulator.Services;

var diceService = new DiceService();
var activationService = new ActivationService(diceService);

var results = new List<Result>();

for (int i = 1; i < 10_000; i++)
{
	var a = new Unit("Infantry", 4, 4) { Size = 10, Weapons = new List<Weapon> { new Weapon(1) } };
	var b = new Unit("Tank", 4, 4) { Tough = 10, Weapons = new List<Weapon> { new Weapon(10) } };
	
	var result = new Result();
	int j = 0;
	while (a.Size > 0 && b.Size > 0)
	{
		bool even = j++ % 2 == 0;
		var attacker = even ? a : b;
		var defender = even ? b : a;

		result.AttacksToKill++;

		activationService.Attack(attacker, defender);
	}

	result.Winner = a.Size > 0 ? a : b;
	results.Add(result);
	
	Console.WriteLine();
}

foreach (var group in results.GroupBy(x => new { x.Winner.Name }))
{
	Console.WriteLine(group.Key + " won " + group.Count());
}

Console.WriteLine("Finished...");