using AssistenteFinanceiro.Domain.Enums;
using AssistenteFinanceiro.Domain.Model.Contas.ValueObjects;
using AssistenteFinanceiro.Infra.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssistenteFinanceiro.Domain.Model
{
    public class Conta : BaseEntity
    {
        protected Conta() { }

        public Conta(Guid codigo, NomeConta nome, DescricaoConta descricao, IconeConta icone)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
        }

        public Conta(NomeConta nome, DescricaoConta descricao, IconeConta icone, decimal saldoInicial = 0)
        {
            Nome = nome;
            Descricao = descricao;
            Icone = icone;
            SaldoInicial = saldoInicial;
            SaldoAtual = saldoInicial;
            DataCriacao = DateTime.Now;

            Transacoes = new List<Transacao>();
            //Orcamentos = new List<Orcamento>();
            //Objetivos = new List<Objetivo>();
        }

        public NomeConta Nome { get; private set; }
        public DescricaoConta Descricao { get; private set; }
        public IconeConta Icone { get; private set; }
        public decimal SaldoInicial { get; private set; }
        public decimal SaldoAtual { get; private set; }

        public void Renomear(NomeConta novoNome)
        {
            Nome = novoNome;
        }

        public void AtualizarIcone(IconeConta novoIcone)
        {
            Icone = novoIcone;
        }

        public ICollection<Transacao> Transacoes { get; }
        //public ICollection<Orcamento> Orcamentos { get; }
        //public ICollection<Objetivo> Objetivos { get; }

        public int TransacoesRealizadas() => Transacoes.Count(t => t.Efetivada);
        public int TransacoesPendentes() => Transacoes.Count(t => !t.Efetivada);

        public void AdicionarTransacao(Transacao transacao)
        {
            if (Transacoes.Contains(transacao))
                return;

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
            if (!Transacoes.Contains(transacao))
                return;

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
