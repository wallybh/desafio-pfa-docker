# Desafio aceleração docker

## Aplicação: Desenvolvimento

Para executar os comandos do sdk e debugar sem a necessidade de instalar o sdk na máquina de desenvolvimento, utilize o comando:

> docker run -it --rm -p 8080:5000 -v $(pwd)/app:/app --network bridge mcr.microsoft.com/dotnet/sdk:5.0 bash

Dessa forma não há necessidade de instalar o framework na sua máquina.

Para começar a executar a aplicação em modo de desenvolvimento, dentro do container de dev, navegue até a pasta /app e execute o comando:

> dotnet watch run

## Aplicação: Variáveis de ambiente

As seguintes variáveis de ambientes parametrizam a conexão com o banco de dados:

- MYSQL_SERVER
    - Nome do servidor de banco de dadosBanco de dados. Default: localhost
- MYSQL_PORT
    - Porta onde o mysql está sendo executado. Default: 3306
- MYSQL_DB
    - Nome do banco de dados. Default: desafio_pfa_docker
- MYSQL_USER
    - Usuário que tem acesso ao banco de dados. Default: root
- MYSQL_PSW
    - Senha do usuário do banco de dados. Default: Vazio
