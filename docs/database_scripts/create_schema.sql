CREATE EXTENSION IF NOT EXISTS "pgcrypto";

create table CONTAS( 
	CODIGO uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
	NOME varchar(255) NOT NULL,
	DESCRICAO varchar(1000) NOT NULL,
	SALDO_INICIAL numeric(8, 2) default 0 NOT NULL,
	SALDO_ATUAL numeric(8, 2) default 0 NOT NULL,
	NOME_ICONE varchar(50) NOT NULL,
	COR_ICONE varchar(12) NOT NULL,
	DATA_CRIACAO timestamp not null default now(),
	DATA_ATUALIZACAO timestamp not null default now(),
	APAGADO boolean not null default false
);

create table TRANSACOES(
	CODIGO uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
	CODIGO_CONTA uuid NOT NULL,
	VALOR numeric(8, 2) NOT NULL, 
	TIPO numeric(1) NOT NULL,
	DATA_LANCAMENTO timestamp not null default now(),
	DATA_EFETIVACAO timestamp not null default now(),
	DATA_CRIACAO timestamp not null default now(),
	DATA_ATUALIZACAO timestamp not null default now(),
	APAGADO boolean not null default false
);

alter table transacoes add foreign key (CODIGO_CONTA) references contas(codigo);