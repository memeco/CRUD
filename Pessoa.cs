using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Crud
{
    public class Pessoa
    {
        // Propriedades da classe Pessoa
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        // Construtor da classe Pessoa
        public Pessoa(int id, string nome, int idade, double altura, double peso)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Altura = altura;
            Peso = peso;
        }
        
        // Método para criar um registro de Pessoa no banco de dados
        public void Criar()
        {
            // Inicia um bloco `using` para garantir que a conexão com o banco de dados será fechada corretamente após o uso.
            using (MySqlConnection conn = Database.GetConnection())
            {
                // Define a consulta SQL para inserir um novo registro na tabela `dbPerson`.
                string query = "INSERT INTO dbPerson (id, nome, idade, altura, peso) VALUES (@Id, @Nome, @Idade, @Altura, @Peso)";

                // Cria um objeto `MySqlCommand` com a consulta SQL e a conexão `conn`.
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // Adiciona os parâmetros à consulta SQL. Esses parâmetros serão substituídos pelos valores reais ao executar a consulta.
                cmd.Parameters.AddWithValue("@Id", Id);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Idade", Idade);
                cmd.Parameters.AddWithValue("@Altura", Altura);
                cmd.Parameters.AddWithValue("@Peso", Peso);

                // Abre a conexão com o banco de dados.
                conn.Open();

                // Executa a consulta SQL definida anteriormente.
                cmd.ExecuteNonQuery();
            }

        }

        // Método estático para ler registros de Pessoa no banco de dados
        
        // Método para editar um registro de Pessoa no banco de dados
        
        // Método estático para excluir um registro de Pessoa no banco de dados

    }
}
