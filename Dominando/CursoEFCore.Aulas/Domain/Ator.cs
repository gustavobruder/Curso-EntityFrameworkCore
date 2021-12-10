using System.Collections.Generic;

namespace CursoEFCore.Aulas.Domain
{
    public class Ator
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Filme> Filmes { get; } = new List<Filme>();
    }
}