CREATE EXTENSION "pgcrypto";

create table CONTAS( 
	CODIGO uuid PRIMARY KEY DEFAULT gen_random_uuid() NOT NULL,
	TIPO numeric(4) NOT NULL,
	SALDO_INICIAL numeric(8, 2) default 0 NOT NULL,
	SALDO_ATUAL numeric(8, 2) default 0 NOT NULL,
	NOME varchar(255) NOT NULL,
	DESCRICAO varchar(1000) NOT NULL,
	NOME_ICONE varchar(50) NOT NULL,
	COR_ICONE varchar(12) NOT NULL
);