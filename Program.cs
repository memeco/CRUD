using System;
using System.Collections.Generic;

namespace Crud
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Criar uma pessoa");
                Console.WriteLine("2 - Ler pessoas");
                Console.WriteLine("3 - Editar uma pessoa");
                Console.WriteLine("4 - Excluir uma pessoa");
                Console.WriteLine("5 - Sair");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CriarPessoa();
                        break;
                    case "2":
                        LerPessoas();
                        break;
                    case "3":
                        EditarPessoa();
                        break;
                    case "4":
                        ExcluirPessoa();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CriarPessoa()
        {
            Console.WriteLine("Digite o ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a Idade:");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Altura:");
            double altura = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Peso:");
            double peso = double.Parse(Console.ReadLine());

            Pessoa pessoa = new Pessoa(id, nome, idade, altura, peso);
            pessoa.Criar();

            Console.WriteLine("Pessoa criada com sucesso!");
        }

        static void LerPessoas()
        {
            List<Pessoa> pessoas = Pessoa.Ler();

            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"ID: {pessoa.Id}, Nome: {pessoa.Nome}, Idade: {pessoa.Idade}, Altura: {pessoa.Altura}, Peso: {pessoa.Peso}");
            }
        }

        static void EditarPessoa()
        {
            Console.WriteLine("Digite o ID da pessoa a ser editada:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite a nova Idade:");
            int idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a nova Altura:");
            double altura = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo Peso:");
            double peso = double.Parse(Console.ReadLine());

            Pessoa pessoa = new Pessoa(id, nome, idade, altura, peso);
            pessoa.Editar();

            Console.WriteLine("Pessoa editada com sucesso!");
        }

        static void ExcluirPessoa()
        {
            Console.WriteLine("Digite o ID da pessoa a ser excluída:");
            int id = int.Parse(Console.ReadLine());

            Pessoa.Excluir(id);

            Console.WriteLine("Pessoa excluída com sucesso!");
        }
    }
}
