using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ap1_main.Domain;
using ap1_main.Data;

namespace ap1_main.Data
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }
        public IList<Cliente> GetAll()
        {
            return context.Cliente.ToList();
        }
        public void Save(Cliente entity)
        {
            context.Add(entity);
            context.SaveChanges();
        }
        public bool Delete(int entityId)
        {
            var cliente = GetById(entityId);
            context.Remove(cliente);
            context.SaveChanges();
            return true;
        }

        public Cliente GetById(int entityId)
        {
            return context.Cliente.SingleOrDefault(x=>x.clienteId == entityId);
        }

        public Cliente GetByCPF(string entityCPF){
            return context.Cliente.SingleOrDefault(x=>x.cpf == entityCPF);
        }

        public void Update(Cliente entity)
        {
            context.Cliente.Update(entity);
            context.SaveChanges();
        }
    }
}