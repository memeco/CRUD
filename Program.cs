using System;

namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            // Perguntando os valores ao usuário
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.Write("Digite a altura (em metros): ");
            double altura = double.Parse(Console.ReadLine());

            Console.Write("Digite o peso (em kg) ou deixe em branco para nulo: ");
            string pesoInput = Console.ReadLine();
            double? peso = string.IsNullOrEmpty(pesoInput) ? (double?)null : double.Parse(pesoInput);

            // Criando um objeto da classe Pessoa com os valores fornecidos pelo usuário
            Pessoa pessoa = new Pessoa(id, nome, idade, altura, peso);

            // Salvando o objeto no banco de dados
            try
            {
                pessoa.Criar();
                Console.WriteLine("Pessoa cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro ao salvar a pessoa no banco de dados: " + ex.Message);
            }
        }
    }
}
