Console.Clear();

string difEscolhida;

List<Dificuldade> difficulty = new List<Dificuldade>
{
    new Dificuldade() {Dif = "1", Rodadas = 8, Escolhido = false},
    new Dificuldade() {Dif = "2", Rodadas = 14, Escolhido = false},
    new Dificuldade() {Dif = "3", Rodadas = 20, Escolhido = false},
    new Dificuldade() {Dif = "4", Rodadas = 31, Escolhido = false}
};

Console.WriteLine("--- Genius ---");

foreach (Dificuldade d in difficulty)
{
    Console.WriteLine($"Dificuldade {d.Dif}: {d.Rodadas} rodadas");
}

Console.Write("\nEscolha a dificuldade que você quer jogar (de 1 à 4): ");
difEscolhida = Console.ReadLine()!;

foreach (Dificuldade d in difficulty)
{
    if (d.Dif == difEscolhida)
    {
        d.Escolhido = true;
    }
}

Vermelho();
Console.WriteLine("Dificuldade inválida!");
ResetaCor();

foreach (Dificuldade d in difficulty)
{
    if (d.Escolhido == true)
    {
        Console.Clear();
        Console.WriteLine($"Dificuldade {d.Dif} escolhida\n");
        Thread.Sleep(500);
        Console.Clear();
        Console.WriteLine("--- Regras ---\n");

        Vermelho();
        Console.Write("1 ");
        ResetaCor();
        Console.Write("para ");
        Vermelho();
        Console.Write("Vermelho\n");
        Verde();
        Console.Write("2 ");
        ResetaCor();
        Console.Write("para ");
        Verde();
        Console.Write("Verde\n");
        Azul();
        Console.Write("3 ");
        ResetaCor();
        Console.Write("para ");
        Azul();
        Console.Write("Azul\n");
        Amarelo();
        Console.Write("4 ");
        ResetaCor();
        Console.Write("para ");
        Amarelo();
        Console.Write("Amarelo\n\n");
        ResetaCor();
        Console.Write("Aperte 'Enter' para iniciar");
        Console.ReadLine();
    }
}


void Vermelho()
{
    Console.ForegroundColor = ConsoleColor.Red;
}

void Verde()
{
    Console.ForegroundColor = ConsoleColor.Green;
}

void Azul()
{
    Console.ForegroundColor = ConsoleColor.DarkCyan;
}

void Amarelo()
{
    Console.ForegroundColor = ConsoleColor.Yellow;
}

void ResetaCor()
{
    Console.ResetColor();
}


class Dificuldade()
{
    public required string Dif;
    public int Rodadas;
    public bool Escolhido;
}