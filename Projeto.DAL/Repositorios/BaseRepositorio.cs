using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Projeto.DAL.Contexto;

namespace Projeto.DAL.Repositorios
{
    public class BaseRepositorio<T>
        where T : class
    {
        public void Inserir(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges();
            }
        }

        public void Atualizar(T obj)
        {
            using(DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Modified;
                d.SaveChanges();
            }
        }

        public void Excluir(T obj)
        {
            using (DataContext d = new DataContext())
            {
                d.Entry(obj).State = EntityState.Deleted;
                d.SaveChanges();
            }
        }

        public List<T> ListarTodos()
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().ToList();
            }
        }

        public T ObterPorId(int id)
        {
            using (DataContext d = new DataContext())
            {
                return d.Set<T>().Find(id);
            }
        }
    }
}
