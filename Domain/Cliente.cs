using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ap1_main.Domain
{
    public class Cliente
    {
        [Key]
        public int clienteId {get; set;}
        [ForeignKey("Conta")]
        public string nome { get; set;}
        public string cpf {get; set;}    
        public string endereco { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public ICollection<Conta> Contas { get; set;}
        
        public Cliente(){

        }

        /*public Cliente(string nome, string cpf, string endereco, string telefone, string email, Conta conta){
            this.nome = nome; 
            this.cpf = cpf;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.contaId = conta.contaId;
        }*/
        
    }
}