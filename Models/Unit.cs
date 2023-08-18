namespace OprSimulator.Models;

public class Unit
{
	public Unit(string name, int quality, int defense)
	{
		Name = name;
		Quality = quality;
		Defense = defense;
	}

	public string Name { get; set; }
	public int Quality { get; set; }
	public int Defense { get; set; }
	public int Size { get; set; } = 1;
	public int Tough { get; set; } = 1;

	public int Wounds { get; set; }

	public IEnumerable<Weapon> Weapons { get; set; }

	public void AssignDamage(int damage)
	{
		Wounds += damage;
		int killModels = Wounds / Tough;
		Size -= killModels;
		Wounds = Wounds % Tough;
	}

}
