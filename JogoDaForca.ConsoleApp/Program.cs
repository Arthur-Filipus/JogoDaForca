using System.Threading.Channels;

namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //faltando: refatoração
            
            string [] palavras = {"ABACATE", "ABACAXI", "ACEROLA", "AÇAÍ", "ARAÇA", "ABACATE", "BACABA", "BACURI", "BANANA",
                "CAJÁ", "CAJÚ", "CARAMBOLA", "CUPUAÇU", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA",
                "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA", "UVAIA"};
            Random random = new Random();

            string palavraaleatoria = palavras[random.Next(palavras.Length)];

            char letra;

            string[] resultado = new string[palavraaleatoria.Length];

            int partecorpototal = 5;

            int partecorpoatual = 0;

            int chances = 5;

            int erros = 0;

            bool letraencontrada = false;

            bool palavracompleta = false;

            string[] forca = {
    "__________________",
    " |/              |",
    " |               o",
    " |              /|\\",
    " |              / \\",
    " |\n |\n |\n |\n_|_____"};

            string[] forcaAtual = {
    "__________________",
    " |/              |",
    " |",
    " |",
    " |",
    " |\n |\n |\n |\n_|_____" };

            Console.WriteLine("   O JOGO DA MORTE DA AZARAÇÃO, *O JOGO DA FORCA*\n");
            foreach (string linha in forcaAtual)
            {
                Console.WriteLine(linha);
            }

            for (int i = 0; i < palavraaleatoria.Length; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();
            while (chances != 0 && !palavracompleta || partecorpoatual > partecorpototal)
            {
                Console.WriteLine($"Você possui {chances} tentatívas!");
                Console.Write("Digite uma letra: ");
                letra = Convert.ToChar(Console.ReadLine().ToUpper());
                letraencontrada = false;
                for (int j = 0; j < palavraaleatoria.Length; j++)
                {
                    if (letra.ToString() == palavraaleatoria[j].ToString())
                    {
                        resultado[j] = letra.ToString();
                        letraencontrada = true;
                    }
                    if (resultado[j] == null)
                    {
                        resultado[j] = "_";
                    }
                }
                if (!letraencontrada)
                {
                    chances--;
                    erros++;
                    partecorpoatual++;
                    Console.WriteLine($"ERROUUU, ainda tem {chances} tentatívas.");
                    forcaAtual[0 + erros] = forca[0 + erros];
                }
                
                Console.WriteLine();
                foreach (string linha in forcaAtual)
                {
                    Console.WriteLine(linha);
                }
                foreach (string item in resultado)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
                Console.WriteLine();
                
                if (!resultado.Contains("_"))
                {
                    Console.WriteLine("Parabens por vencer o jogo!");
                    palavracompleta = true;
                    chances = 0;
                }
            }
            if (partecorpoatual >= partecorpototal)
            {
                Console.WriteLine("Perdeu, Ruim");
            }
            Console.ReadLine();
        }
    }
}