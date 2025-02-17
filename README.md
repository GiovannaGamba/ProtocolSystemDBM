# Protocol System DBM


### Requisitos para executar o projeto no Windows:

- [Visual Studio para visualização do código e execução dos comandos](https://visualstudio.microsoft.com/pt-br/downloads/)
- [GIT para Windows, para versionamento do projeto](https://git-scm.com/download/win)
- [Docker Desktop para containerização do SQL Server](https://www.docker.com/products/docker-desktop/)
- [Download do Beekeeper para visualização da base de dados](https://www.beekeeperstudio.io/get)

### Execução do Projeto:

Escolha um diretório de sua preferência e clone o projeto:
```
git clone https://github.com/GiovannaGamba/ProtocolSystemDBM
```
Garanta que o Docker está em execução para os próximos passos:

1. Execute o comando `docker-compose up -d` na raiz do projeto, onde é encontrado o arquivo docker-compose.yml.
2. Abra o Package Manager Console no Visual Studio e execute o comando `Update-Database` para aplicar a migration no banco de dados.
3. Execute o projeto usando HTTPS.

Para validar se tudo deu certo, o sistema deve ser compilado e iniciado sem erros, e você conseguirá conectar-se ao banco de dados utilizando estas credenciais no Beekeeper:

      USUÁRIO: sa
      SENHA: 1q2w3e4r@#$
      BANCO DE DADOS: master