// See https://aka.ms/new-console-template for more information
using OprSimulator.Models;
using OprSimulator.Services;

var diceService = new DiceService();
var activationService = new ActivationService(diceService);

var results = new List<Result>();

for (int i = 1; i < 1_000; i++)
{
	var a = new Unit("Infantry", 4, 4) { Size = 10, Weapons = new List<Weapon> { new Weapon(1) } };
	var b = new Unit("Tank", 4, 4) { Tough = 10, Weapons = new List<Weapon> { new Weapon(10) } };

	bool even = i % 2 == 0;
	var attacker = even ? a : b;
	var defender = even ? b : a;
	var result = new Result();

	while (a.Size > 0 && b.Size > 0)
	{
		result.AttacksToKill++;
		
		activationService.Attack(attacker, defender);
	}

	result.Winner = a.Size > 0 ? a : b;
	results.Add(result);
	
	Console.WriteLine();
}

antage Console.WriteLine("Finished...");