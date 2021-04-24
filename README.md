# Desafio aceleração docker

## Aplicação: Desenvolvimento

Para executar os comandos do sdk e debugar sem a necessidade de instalar o sdk na máquina de desenvolvimento, utilize o comando:

> docker run -it --rm -p 8080:5000 -v $(pwd)/app:/app --network bridge mcr.microsoft.com/dotnet/sdk:5.0 bash

Dessa forma não há necessidade de instalar o framework na sua máquina.

Para começar a executar a aplicação em modo de desenvolvimento, dentro do container de dev, navegue até a pasta /app e execute o comando:

> dotnet watch run

