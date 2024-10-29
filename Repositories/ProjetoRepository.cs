using Exo.WebApi.Contexts;  // Ajuste no namespace correto
using Exo.WebApi.Models;     // Ajuste no namespace correto
using System.Collections.Generic;
using System.Linq;

namespace Exo.WebApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            _context.SaveChanges();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projetos.Find(id);
        }

        public void Atualizar(int id, Projeto projeto)
        {
            var projetoBuscado = _context.Projetos.Find(id);
            if (projetoBuscado != null)
            {
                projetoBuscado.NomeDoProjeto = projeto.NomeDoProjeto;
                projetoBuscado.Area = projeto.Area;
                projetoBuscado.Status = projeto.Status;

                _context.Projetos.Update(projetoBuscado);
                _context.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            var projetoBuscado = _context.Projetos.Find(id);
            if (projetoBuscado != null)
            {
                _context.Projetos.Remove(projetoBuscado);
                _context.SaveChanges();
            }
        }
    }
}
