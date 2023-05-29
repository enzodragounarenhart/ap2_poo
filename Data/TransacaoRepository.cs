using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_main.Domain;
using ap1_main.Data;

namespace ap1_main.Data
{
    public class TransacaoRepository : ITransacaoRepository
    {
        private readonly DataContext context;
        public TransacaoRepository(DataContext context)
        {
            this.context = context;
        }
        public IList<Transacao> GetAll()
        {
            return context.Transacao.ToList();
        }
        public void Save(Transacao entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public bool Delete(int entityId)
        {
            var Transacao = GetById(entityId);
            context.Remove(Transacao);
            context.SaveChanges();
            return true;
        }

        public Transacao GetById(int entityId)
        {
            return context.Transacao.SingleOrDefault(x=>x.transacaoId == entityId);
        }

        public void Update(Transacao entity)
        {
            
        }
    }
}