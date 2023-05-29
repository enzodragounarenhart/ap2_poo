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
    public class Transacao
    {
        [Key]
        public int transacaoId { get; set;}
        [ForeignKey("Conta")]
        public int contaDestinoId;
        [ForeignKey("Conta")]
        public int contaOrigemId;
        public double valor{ get; set;}
        public Conta contaOrigem {get;set;}
        public Conta contaDestino{get;set;}

        public void RealizarTransacao(ContaRepository repConta, Conta contaOrigem, Conta contaDestino, double valor){
            contaOrigem.saldo = contaOrigem.saldo - valor;
            contaDestino.saldo = contaDestino.saldo + valor;
            repConta.Update(contaDestino);
            repConta.Update(contaOrigem);
        }

        public Transacao(){

        }

        /*public Transacao(Conta contaOrigem, Conta contaDestino, double valor, int contaOrigemId, int contaDestinoId)
        {
            this.contaDestino = contaDestino;
            this.contaOrigem = contaOrigem;
            this.valor = valor;
            this.contaDestinoId = contaDestinoId;
            this.contaOrigemId = contaOrigemId;
        }*/
        
    }
}