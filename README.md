# Desafio aceleração docker

Esse programa deve listar os módulo do curso *Ful Cycle* trazidos de um banco de dados MySQL. A aplicação foi feita pensando em ser executada em um ambiente docker. Também faz parte da aplicação a imagem nginx quer irá trabalhar como servidor proxy reverso, apontando para o container da aplicação.

A aplicação agora poderá ser executada utilizando o docker compose.

## Executando a aplicação no docker:

> docker-compose up -d

As variáveis de ambiente utilizadas aqui são para um ambiente simples focado em uma execução rápida. Consulte as possibilidades de customização das [variáveis de ambientes](#aplicação-variáveis-de-ambiente) definidas abaixo.

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

## Compilando a imagem docker do nginx

1. Certifique-se que está no branch main:
    > git checkout main
2. Cerfitique-se que o branch esteja atualizado com origin:
    > git pull;
3. Navegue até a pasta nginx:
    > cd nginx
4. Execute o comando de build da imagem:
    > docker build -t wrst/desafio-pfa-docker-nginx .
5. Execute o push da imagem docker hub:
    > docker push wrst/desafio-pfa-docker-nginx
