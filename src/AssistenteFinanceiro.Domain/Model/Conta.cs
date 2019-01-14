using AssistenteFinanceiro.Domain.Model.ContaValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System.Collections.Generic;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Conta : AggregateRoot
    {
        protected Conta()
        {
        }

        public Conta(NomeConta nome, DescricaoConta descricao, decimal saldoInicial = 0)
        {
            Nome = nome;
            Descricao = descricao;
            SaldoInicial = saldoInicial;
            SaldoAtual = saldoInicial;

            Transacoes = new List<Transacao>();
            Orcamentos = new List<Orcamento>();
            Objetivos = new List<Objetivo>();
        }

        public NomeConta Nome { get; }
        public DescricaoConta Descricao { get; }
        public decimal SaldoInicial { get; }
        public decimal SaldoAtual { get; private set; }

        public List<Transacao> Transacoes { get; }
        public List<Orcamento> Orcamentos { get; }
        public List<Objetivo> Objetivos { get; }

        public void AdicionarTransacao(Transacao transacao)
        {
            if (transacao.IsReceita())
            {
                SaldoAtual += transacao.Valor;
            } 
            else
            {
                SaldoAtual -= transacao.Valor;
            }

            Transacoes.Add(transacao);          
        }

        public void RemoverTransacao(Transacao transacao)
        {
            if (transacao.IsDespesa())
            {
                SaldoAtual += transacao.Valor;
            }
            else
            {
                SaldoAtual -= transacao.Valor;
            }

            Transacoes.Remove(transacao);
        }
    }
}
