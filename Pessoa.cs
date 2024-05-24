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
        public static List<Pessoa> Ler()
        {
            // Inicializa uma nova lista de Pessoa
            List<Pessoa> pessoas = new List<Pessoa>();
            
            // Cria uma conexão com o banco de dados usando o método GetConnection
            using (MySqlConnection conn = Database.GetConnection())
            {
                // Define a consulta SQL que será executada no banco de dados
                string query = "SELECT * FROM dbPerson";
                
                // Cria um comando MySqlCommand com a consulta e a conexão
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                // Abre a conexão com o banco de dados
                conn.Open();
                
                // Executa a consulta e obtém um MySqlDataReader para ler os dados retornados
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    // Loop através das linhas retornadas pelo MySqlDataReader
                    while (reader.Read())
                    {
                        // Cria um novo objeto Pessoa a partir dos dados da linha atual
                        Pessoa pessoa = new Pessoa(
                            reader.GetInt32(0),  // Obtém o valor da primeira coluna como inteiro (ID)
                            reader.GetString(1), // Obtém o valor da segunda coluna como string (Nome)
                            reader.GetInt32(2),  // Obtém o valor da terceira coluna como inteiro (Idade)
                            reader.GetDouble(3), // Obtém o valor da quarta coluna como double (Altura)
                            reader.GetDouble(4)  // Obtém o valor da quinta coluna como double (Peso)
                        );
                        
                        // Adiciona o objeto Pessoa à lista de pessoas
                        pessoas.Add(pessoa);
                    }
                }
            }
            
            // Retorna a lista de pessoas
            return pessoas;
        }

        // Método para editar um registro de Pessoa no banco de dados
        public void Editar()
        {
            // Inicia um bloco `using` para garantir que a conexão com o banco de dados será fechada corretamente após o uso.
            using (MySqlConnection conn = Database.GetConnection())
            {
                // Define a consulta SQL para atualizar um registro na tabela `dbPerson`.
                string query = "UPDATE dbPerson SET nome = @Nome, idade = @Idade, altura = @Altura, peso = @Peso WHERE id = @Id";
                
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

        // Método estático para excluir um registro de Pessoa no banco de dados
        public static void Excluir(int id)
        {
            // Inicia um bloco `using` para garantir que a conexão com o banco de dados será fechada corretamente após o uso.
            using (MySqlConnection conn = Database.GetConnection())
            {
                // Define a consulta SQL para excluir um registro na tabela `dbPerson`.
                string query = "DELETE FROM dbPerson WHERE id = @Id";
                
                // Cria um objeto `MySqlCommand` com a consulta SQL e a conexão `conn`.
                MySqlCommand cmd = new MySqlCommand(query, conn);
                
                // Adiciona os parâmetros à consulta SQL. Esses parâmetros serão substituídos pelos valores reais ao executar a consulta.
                cmd.Parameters.AddWithValue("@Id", id);
                
                // Abre a conexão com o banco de dados.
                conn.Open();
                
                // Executa a consulta SQL definida anteriormente.
                cmd.ExecuteNonQuery();
            }
        }
    }
}
