using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TesteDevJR.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;

namespace TesteDevJR.Repository
{
    public class CidadeRepository : ICidadeRepository
    {
        [TempData]
        public string Message { get; set; }

        IConfiguration _configuration;

        public CidadeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("CidadesConnection").Value;
            return connection;
        }

        public int Add(Cidade cidade)
        {
            var connectionString = this.GetConnection();
            int count = 0;
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "INSERT INTO Cidades(NomeCidade, UF) VALUES(@NomeCidade, @UF)";
                    count = con.Execute(query, cidade);
                }

                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Delete(int Codigo)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "DELETE FROM Cidades WHERE Codigo = " + Codigo;
                    count = con.Execute(query);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public int Edit(Cidade cidade)
        {
            var connectionString = this.GetConnection();
            var count = 0;

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "UPDATE Cidades SET NomeCidade = @NomeCidade, UF = @UF WHERE Codigo = " + cidade.Codigo;
                    count = con.Execute(query, cidade);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return count;
            }
        }

        public Cidade Get(int Codigo)
        {
            var connectionString = this.GetConnection();
            Cidade cidade = new Cidade();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Cidades WHERE Codigo = " + Codigo;
                    cidade = con.Query<Cidade>(query).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return cidade;
            }
        }

        public List<Cidade> GetCidades()
        {
            var connectionString = this.GetConnection();
            List<Cidade> cidades = new List<Cidade>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "SELECT * FROM Cidades";
                    cidades = con.Query<Cidade>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return cidades;
            }
        }

        public List<Cidade> GetCidadesPorUF()
        {
            var connectionString = this.GetConnection();
            List<Cidade> cidades = new List<Cidade>();

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = "EXEC quantidadeCidades";
                    cidades = con.Query<Cidade>(query).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return cidades;
            }
        }

    }
}
