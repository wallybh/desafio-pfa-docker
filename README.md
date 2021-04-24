# Desafio aceleração docker

## Executando a aplicação no docker (desenvolvimento):

### Método 1: manualmente

1. Crie uma rede do tipo bridge:
    > docker network create --driver=bridge desafio-pfa-docker
2. Crie o container para o banco de dados:
    > docker run -d --rm -e "MYSQL_ALLOW_EMPTY_PASSWORD=true" -e "MYSQL_DATABASE=desafio_pfa_docker" --network desafio-pfa-docker --name desafio-pfa-db mysql:8.0
3. Crie o container para a aplicação:
    > docker run -d --rm -p 80:80 --network desafio-pfa-docker -e "MYSQL_SERVER=desafio-pfa-db" --name desafio-pfa-web wrst/desafio-pfa-docker-web

## Compilando a imagem docker da aplicação

1. Certifique-se que está no branch main:
    > git checkout main
2. Cerfitique-se que o branch esteja atualizado com origin:
    > git pull;
3. Navegue até a pasta app:
    > cd app
4. Execute o comando de build da imagem:
    > docker build -t wrst/desafio-pfa-docker-web .
5. Execute o push da imagem docker hub:
    > docker push wrst/desafio-pfa-docker-web

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
