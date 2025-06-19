Console.Clear();

Random randomizar = new Random();

string difEscolhida;
int RodadasMax;
int RodadAtual = 1;

List<Dificuldade> difficulty = new List<Dificuldade>
{
    new Dificuldade() {Dif = "1", Rodadas = 8, Escolhido = false},
    new Dificuldade() {Dif = "2", Rodadas = 14, Escolhido = false},
    new Dificuldade() {Dif = "3", Rodadas = 20, Escolhido = false},
    new Dificuldade() {Dif = "4", Rodadas = 31, Escolhido = false}
};

Queue<string> filaPao = new Queue<string>();
    filaPao.Enqueue("Anastacia");
    filaPao.Enqueue("Deodato");
    filaPao.Enqueue("Madalena");

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
Console.WriteLine("Dificuldade inválida");
ResetaCor();

foreach (Dificuldade d in difficulty)
{
    if (d.Escolhido == true)
    {
        RodadasMax = d.Rodadas;
        Console.Clear();
        Console.WriteLine($"Dificuldade {d.Dif} escolhida\n");
        Thread.Sleep(1500);
        Console.Clear();

    menuregras:
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

        Console.WriteLine("Deseja ouvir os sons novamente? Pressione 'R'\n");
        Console.WriteLine("Deseja começar o jogo? Pressione 'Enter'");

        ConsoleKey continuar = Console.ReadKey(true).Key;

        while (continuar != ConsoleKey.Enter)
        {
            if (continuar == ConsoleKey.R)
            {
                Console.Clear();
                goto menuregras;
            }
            else
            {
                continuar = Console.ReadKey(true).Key;
            }
        }
        
    Jogo:
        Console.Clear();
        Console.WriteLine($"Rodada {RodadAtual}\n");
    
        if (RodadAtual < RodadasMax)
        {
            RodadAtual++;

            goto Jogo;
        }
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

