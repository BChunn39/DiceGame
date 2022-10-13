using System.Xml.XPath;

bool playAgain;
do
{
    int diceOne, diceTwo;

    DiceRandom(out diceOne, out diceTwo);
    
    string results = DiceRolls(diceOne, diceTwo);
    Console.WriteLine(results);
    DiceTotal(diceOne, diceTwo);
    Console.WriteLine("Would you like to play again (y/n)?");
    string input = Console.ReadLine();
    playAgain = input.ToLower() == "y";
} while (playAgain == true);

int DiceRandom(out int diceOne, out int diceTwo)
{
    Console.WriteLine("Pleae enter the number of sides for a normal dice.");
    int diceSides;
    bool isValid = int.TryParse(Console.ReadLine(), out diceSides);
    if (!isValid)
    {
        Console.WriteLine("This is not a valid number please enter another number.");
        Environment.Exit(0);
    }
    Random random = new Random();
    
    diceOne = random.Next(1, diceSides);
    diceTwo = random.Next(1, diceSides);
    return diceSides;
}

string DiceRolls(int diceOne, int diceTwo)
{
    string results;
    if (diceOne == 1 && diceTwo == 1)
    {
        results = "You rolled Snake eyes! both your rolls came up as 1's";
    }
    else if (diceOne == 2 && diceTwo == 2 || diceOne == 1 && diceTwo == 2)
    {
        results = $"You rolled Ace Duce! you first dice was {diceOne} and your second dice was {diceTwo}.";
    }
    else if (diceOne == 6 && diceTwo == 6)
    {
        results = "You rolled Box Cars!! Both your dice show 6's.";
    }
    else
    {
        results = $"You rolled dice one as {diceOne} and dice two as {diceTwo}";
    }
    return results;
}

int DiceTotal(int diceOne, int diceTwo)
{
    int totalRoll = diceOne + diceTwo;
    {
        if (totalRoll == 2 || totalRoll == 3 || totalRoll == 12)
        {
            Console.WriteLine($"You rolled {totalRoll}. Craps! this is not a win!");
        }
        else if (totalRoll == 7 || totalRoll == 11)
        {
            Console.WriteLine($"You rolled {totalRoll}. This is a winning roll! Congrats!");
        }
        else
        {
            Console.WriteLine($"You rolled {totalRoll}. This is a losing roll.");
        }
        return totalRoll;
    }
}
Console.ReadKey();



