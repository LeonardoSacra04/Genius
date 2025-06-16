Console.Clear();

int difEscolhida;

List<Dificuldade> difficulty = new List<Dificuldade>
{
    new Dificuldade() {Dif = 1, Rodadas = 8, Escolhido = false},
    new Dificuldade() {Dif = 2, Rodadas = 14, Escolhido = false},
    new Dificuldade() {Dif = 3, Rodadas = 20, Escolhido = false},
    new Dificuldade() {Dif = 4, Rodadas = 31, Escolhido = false}
};

Console.WriteLine("--- Genius ---");

foreach (Dificuldade d in difficulty)
{
    Console.WriteLine($"Dificuldade {d.Dif}: {d.Rodadas} rodadas");
}

Console.Write("\nEscolha a dificuldade que você quer jogar (de 1 à 4): ");
difEscolhida = Convert.ToInt32(Console.ReadLine()!);

foreach (Dificuldade d in difficulty)
{
    if (d.Dif == difEscolhida)
    {
        d.Escolhido = true;
    }
}

CorVermelha();
Console.WriteLine("Dificuldade inválida!");
ResetaCor();

foreach (Dificuldade d in difficulty)
{
    if (d.Escolhido == true)
    {
        Console.Clear();
        Console.WriteLine($"Dificuldade {d.Dif} escolhida");
    }
}


void CorVermelha()
{
    Console.ForegroundColor = ConsoleColor.Red;
}

void ResetaCor()
{
    Console.ResetColor();
}


class Dificuldade()
{
    public int Dif;
    public int Rodadas;
    public bool Escolhido;
}