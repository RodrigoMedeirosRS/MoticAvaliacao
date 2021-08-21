CREATE TABLE categoria (
  codigo SERIAL  NOT NULL ,
  nome INTEGER   UNIQUE   NOT NULL   ,
PRIMARY KEY(codigo));

CREATE TABLE nomecriterio (
  codigo SERIAL  NOT NULL ,
  nome VARCHAR(100)   UNIQUE   NOT NULL ,
  peso INTEGER   NOT NULL   ,
PRIMARY KEY(codigo));

CREATE TABLE avaliador (
  codigo SERIAL  NOT NULL ,
  nome VARCHAR(50)   NOT NULL ,
  sobrenome VARCHAR(150)   NOT NULL ,
  cpf VARCHAR(11)   UNIQUE   NOT NULL ,
  senha VARCHAR(20)   NOT NULL ,
  email VARCHAR(100)    ,
  telefone VARCHAR(20)      ,
PRIMARY KEY(codigo));

CREATE TABLE trabalho (
  codigo SERIAL  NOT NULL ,
  categoria INTEGER   NOT NULL ,
  nome VARCHAR(200)   UNIQUE   NOT NULL ,
  escola VARCHAR(200)   NOT NULL ,
  anoapresentacao TIMESTAMP   NOT NULL   ,
PRIMARY KEY(codigo)  ,
  FOREIGN KEY(categoria)
    REFERENCES categoria(codigo));

CREATE INDEX trabalho_FKIndex1 ON trabalho (categoria);
CREATE INDEX IFK_Rel_03 ON trabalho (categoria);

CREATE TABLE avaliacao (
  codigo SERIAL  NOT NULL ,
  avaliador INTEGER   NOT NULL ,
  trabalho INTEGER   NOT NULL   ,
PRIMARY KEY(codigo)    ,
  FOREIGN KEY(avaliador)
    REFERENCES avaliador(codigo),
  FOREIGN KEY(trabalho)
    REFERENCES trabalho(codigo));

CREATE INDEX avaliador_trabalho_FKIndex1 ON avaliacao (avaliador);
CREATE INDEX avaliador_trabalho_FKIndex2 ON avaliacao (trabalho);

CREATE INDEX IFK_Rel_01 ON avaliacao (avaliador);
CREATE INDEX IFK_Rel_02 ON avaliacao (trabalho);


CREATE TABLE criterio (
  codigo SERIAL  NOT NULL ,
  avaliacao INTEGER   NOT NULL ,
  nomecriterio INTEGER   NOT NULL ,
  descricao VARCHAR(500)    ,
  observacao VARCHAR(500)    ,
  nota FLOAT      ,
PRIMARY KEY(codigo)    ,
  FOREIGN KEY(nomecriterio)
    REFERENCES nomecriterio(codigo),
  FOREIGN KEY(avaliacao)
    REFERENCES avaliacao(codigo));

CREATE INDEX criterio_FKIndex1 ON criterio (nomecriterio);
CREATE INDEX criterio_FKIndex2 ON criterio (avaliacao);

CREATE INDEX IFK_Rel_04 ON criterio (nomecriterio);
CREATE INDEX IFK_Rel_09 ON criterio (avaliacao);



