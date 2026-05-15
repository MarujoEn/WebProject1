using MySql.Data.MySqlClient;
using WebProject1.Interfaces;
using WebProject1.Models;

namespace WebProject1.Repositories
{
    public class UserRepositorie(IConfiguration config) : IUserRepositorie // Herança
    {
        //variavel privada e somente leitura para armazenar a string de conexão
        private readonly string _connectionString = config.GetConnectionString("Connection");
        //metodo que valida se o usuario existe no banco com base em email e senha
        public LoginViewModel Validate(string UserEmail,  string UserPassword)
        {
            //cria a conexao com o banco de dados MySql o using garante que ela seja fechada
            using var conn = new MySqlConnection(_connectionString);
            //abre conexao com banco de dados
            conn.Open();

            //Define a string do sql usando parametros (@) evita ataques de sql injection
            var sql = "SELECT * FROM users WHERE userEmail = @email AND userPassword = @password";

            //Define quem é o 'adm' que gerencia o banco de dados
            var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@email", UserEmail);
            cmd.Parameters.AddWithValue("@password", UserPassword);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new LoginViewModel
                {
                    UserID = Convert.ToInt32(reader["UserID"]),
                    UserName = reader["UserName"].ToString()!,
                    UserEmail = reader["UserEmail"].ToString()!,
                    UserLevel = reader["UserLevel"].ToString()!

                };

            }
            return null;
        }
    }
}
