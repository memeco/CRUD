using System;

namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            // Perguntando os valores ao usuário
            Console.WriteLine("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a idade: ");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a altura (em metros): ");
            double altura = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o peso (em kg): ");
            double peso = double.Parse(Console.ReadLine());

            // Criando um objeto da classe Pessoa
            Pessoa pessoa = new Pessoa(id, nome, idade, altura, peso);

            // Salvando o objeto no banco de dados
            pessoa.Criar();
            Console.WriteLine("Pessoa cadastrada!");
        }
    }
}
