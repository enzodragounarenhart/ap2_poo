using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_main.Domain;
using ap1_main.Data;

namespace ap1_main.Data
{
    public class ContaRepository : IContaRepository
    {
        private readonly DataContext context;
        public ContaRepository(DataContext context)
        {
            this.context = context;
        }
        public IList<Conta> GetAll()
        {
            return context.Conta.ToList();
        }
        public void Save(Conta entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public bool Delete(int entityId)
        {
            var Conta = GetById(entityId);
            context.Remove(Conta);
            context.SaveChanges();
            return true;
        }

        public Conta GetById(int entityId)
        {
            return context.Conta.SingleOrDefault(x=>x.contaId == entityId);
        }

        public Conta GetByNumero(int entityNumber){
            return context.Conta.SingleOrDefault(x => x.numero == entityNumber);
        }

        public void Update(Conta entity)
        {
            context.Conta.Update(entity);
            context.SaveChanges();
        }
    }
}