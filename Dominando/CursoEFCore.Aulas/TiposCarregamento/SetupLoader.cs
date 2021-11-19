using System.Collections.Generic;
using System.Linq;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;

namespace CursoEFCore.Aulas.TiposCarregamento
{
    public class SetupLoader
    {
        protected static void InserirDados(ApplicationContext db)
        {
            if (!db.Departamentos.Any())
            {
                db.Departamentos.AddRange(
                    new Departamento
                    {
                        Descricao = "Departamento 01",
                        Funcionarios = new List<Funcionario>
                        {
                            new Funcionario
                            {
                                Nome = "Rafael Almeida",
                                CPF = "11111111111",
                            },
                        },
                    },
                    new Departamento
                    {
                        Descricao = "Departamento 02",
                        Funcionarios = new List<Funcionario>
                        {
                            new Funcionario
                            {
                                Nome = "Bruno Brito",
                                CPF = "22222222222",
                            },
                            new Funcionario
                            {
                                Nome = "Eduardo Pires",
                                CPF = "33333333333",
                            },
                        },
                    }
                );

                db.SaveChanges();
                db.ChangeTracker.Clear();
            }
        }
    }
}