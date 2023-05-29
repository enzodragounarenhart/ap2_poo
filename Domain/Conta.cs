using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ap1_main.Data;
using ap1_main.Domain;

namespace ap1_main.Domain
{
    public class Conta
    {   
        [Key]
        public int contaId{get; set;}
        [ForeignKey("Cliente")]
        public int clienteId{ get; set;}
        public int numero { get; set;}
        public double saldo {get; set;}
        public Cliente cliente {get; set;}
        public string clienteCPF { get; set;}

        public Conta(){

        }

        public void Sacar(ContaRepository contaRep, Conta conta, double valor){
            conta.saldo = conta.saldo - valor;
            contaRep.Update(conta);
        }

        public void Depositar(ContaRepository contaRep, Conta conta, double valor){
            conta.saldo = conta.saldo + valor;
            contaRep.Update(conta);
        }

        /*public Conta(int numero, Cliente cliente, double saldo, int clienteId)
        {
            this.numero = numero;
            this.cliente = cliente;
            this.saldo = saldo;
            this.clienteId = clienteId;
        }*/
        
    }
}