# Desafio-Full-Stack

## Técnologias usadas

Back-end:
Desenvolvido usando: C#, API Restful, DotNet, .NET Framework, Entity Framework.

Front-end:
Desenvolvido usando: Vue.js, HTML, CSS e Javascript.

Banco de dados: PostgreSQL

## Pré-requisitos

 - Node 
 - DotNet
 - PostgreSQL

## Execução do projeto
<details>
<summary><strong> ⚠️ Configurações mínimas para execução do projeto</strong></summary><br />

Na sua máquina você deve ter:

 - Sistema Operacional Distribuição Unix
 - Node versão 16
 - DotNet
 - SQLServer
 - Docker (**opcional, mas recomendado**)
 - Docker-compose versão >=1.29.2 (**opcional, mas recomendado**)

➡️ O `node` deve ter versão igual ou superior à `16.15.0 LTS`:
  - Para instalar o nvm, [acesse esse link](https://github.com/nvm-sh/nvm#installing-and-updating);
  - Rode os comandos abaixo para instalar a versão correta de `node` e usá-la:
    - `nvm install 16 --lts`
    - `nvm use 16`
    - `nvm alias default 16`

➡️ O `docker-compose` deve ter versão igual ou superior à`ˆ1.29.2`:
  * Use esse [link de referência para realizar a instalação corretamente no ubuntu](https://www.digitalocean.com/community/tutorials/how-to-install-and-use-docker-compose-on-ubuntu-20-04-pt) ou a [documentação oficial](https://docs.docker.com/compose/install/);
  * Acesse o [link da documentação oficial com passos para desinstalar](https://docs.docker.com/compose/install/uninstall/) caso necessário.

</details>

<details>
<summary><strong> 👨‍💻 Informações Importantes </strong></summary><br />

  1. Clone o repositório
- Utilize o comando: `git clone git@github.com:heliorr/Desafio-Accenture.git`<br />
2. Acesse a pasta do projeto
- Acesse a pasta Desafio-Accenture com `cd Desafio-Accenture`;<br />
3. Suba a aplicação 
 <summary><strong> 🐳 Com Container Docker-Compose </strong></summary><br />

    - Execute o comando `docker-compose up --build` na pasta raíz do projeto;
    - Aguarde que todos os containers estejam saudáveis;
    - Acesse a pasta Back-end e execute os comandos `dotnet ef databaseupdate` e `dotnet run watch`;
    - Acesse em seu browser o endereço: `http://localhost:8080`;

  </details>
  
  Projeto Desenvolvido por [Hélio Souza](https://github.com/heliorr)
