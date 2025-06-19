menuDificuldade:

Console.Clear();

List<Dificuldade> difficulty = new List<Dificuldade>
{
    new Dificuldade() {Dif = "1", Rodadas = 8, Escolhido = false},
    new Dificuldade() {Dif = "2", Rodadas = 14, Escolhido = false},
    new Dificuldade() {Dif = "3", Rodadas = 20, Escolhido = false},
    new Dificuldade() {Dif = "4", Rodadas = 31, Escolhido = false}
};

string[] partes;

List<int> sequencia = new List<int>();
Random randomizar = new Random();

int novoNumero;
int RodadasMax;
int RodadAtual = 1;

bool acertou = true;

string difEscolhida;
string entrada;

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

    menuRegras:
        Console.WriteLine("--- Regras ---\n");
        Console.WriteLine("Uma sequência de cores irá aparecer, acerte a ordem e passe para a próxima rodada");
        Console.WriteLine("Digite os números abaixo de acordo com a ordem mostrada com espaço entre cada número\n");
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

        Console.Write("Exemplo: ");
        Vermelho();
        Console.Write("Vermelho ");
        Amarelo();
        Console.Write("Amarelo ");
        Verde();
        Console.Write("Verde ");
        ResetaCor();
        Console.Write(" =>  ");
        Vermelho();
        Console.Write("1 ");
        Amarelo();
        Console.Write("4 ");
        Verde();
        Console.Write("2 \n\n");
        ResetaCor();

        Console.WriteLine("Pressione 'R' para repetir o áudio");
        Console.WriteLine("Pressione 'Enter' para começar");

        ConsoleKey continuar = Console.ReadKey(true).Key;

        while (continuar != ConsoleKey.Enter)
        {
            if (continuar == ConsoleKey.R)
            {
                Console.Clear();
                goto menuRegras;
            }
            else
            {
                continuar = Console.ReadKey(true).Key;
            }
        }

        while (d.Escolhido == true)
        {
            if (RodadAtual > RodadasMax)
            {
                break;
            }

            novoNumero = randomizar.Next(1, 5);
            sequencia.Add(novoNumero);

            Console.Clear();
            Console.WriteLine($"Rodada {RodadAtual}\n");
            RodadAtual++;
            Console.WriteLine("A sequência correta era: " + string.Join(" ", sequencia));
            entrada = Console.ReadLine()!;
            partes = entrada.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (partes.Length != sequencia.Count)
            {
                Console.WriteLine("Sequência de números incorreta! Fim de jogo.");
                Console.WriteLine("A sequência correta era: " + string.Join(" ", sequencia));
                d.Escolhido = false;
                return;
            }

            for (int i = 0; i < sequencia.Count; i++)
            {
                if (!int.TryParse(partes[i], out int numeroDigitado) || numeroDigitado != sequencia[i])
                {
                    acertou = false;
                    break;
                }
            }

            if (!acertou)
            {
                Console.WriteLine("Sequência de números incorreta! Fim de jogo.");
                Console.WriteLine("A sequência correta era: " + string.Join(" ", sequencia));
                d.Escolhido = false;
                return;
            }
        }

        Console.WriteLine("Parabéns, você venceu!");
        Console.WriteLine("Pressione 'D' para voltar para a página de Dificuldade");
        Console.WriteLine("Pressione 'Enter' para voltar para finalizar o jogo");
        continuar = Console.ReadKey().Key;

        while (continuar != ConsoleKey.Enter)
        {
            if (continuar == ConsoleKey.D)
            {
                Console.Clear();
                goto menuDificuldade;
            }
            else
            {
                continuar = Console.ReadKey(true).Key;
            }
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

