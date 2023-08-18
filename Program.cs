// See https://aka.ms/new-console-template for more information
using OprSimulator.Models;
using OprSimulator.Services;

var diceService = new DiceService();
var activationService = new ActivationService(diceService);
var duelService = new DuelService(activationService);
// var a = new Unit("Infantry", 4, 4) { Size = 10, Weapons = new List<Weapon> { new Weapon(1) } };
// var b = new Unit("Tank", 4, 4) { Tough = 10, Weapons = new List<Weapon> { new Weapon(10) } };

//var a = new Unit("[3] T3", 4, 4) { Size = 3, Tough = 3, Weapons = new List<Weapon> { new Weapon(3) } };
var a = new Unit("[14]", 4, 4) { Size = 14, Weapons = new List<Weapon> { new Weapon(1) } };
var b = new Unit("[1] T10", 4, 4) { Tough = 10, Weapons = new List<Weapon> { new Weapon(10) } };

duelService.Duel(a, b);

Console.WriteLine("Finished...");