using Microsoft.EntityFrameworkCore;
using ProjetoValidacao.Models;

namespace ProjetoValidacao.API.Repositorio
{
    public class ContaRepositorio
    {
        private readonly AppDbContext _context;

        public ContaRepositorio(AppDbContext context)
        {
            _context = context;
        }

        public List<Conta> Listar()
        {
            return _context.Contas.ToList();
        }

        public Conta Obter(string nome)
        {
            return _context.Contas.FirstOrDefault(x => x.Nome.ToLower().Equals(nome.ToLower()));
        }

        public bool Inserir(Conta model)
        {
            _context.Contas.Add(model);
            return _context.SaveChanges() > 0;
        }

        public bool Alterar(Conta model)
        {
            _context.Contas.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        public bool Excluir(Conta model)
        {
            _context.Contas.Remove(model);
            return _context.SaveChanges() > 0;
        }
    }
}
