# GameStore API

## Índice

- [Introdução](#introdução)
- [Instalação](#instalação)
- [Uso](#uso)
- [Endpoints](#endpoints)

## Introdução

GameStore API foi desenvolvida utilizando ASP.NET Core. Possui funcionalidades para gerenciar uma loja de jogos com endpoints que realizam operações CRUD (Create, Read, Update, Delete).

## Instalação

Siga os passos abaixo para configurar o ambiente de desenvolvimento local:

1. Clone o repositório:
    ```bash
    git clone https://github.com/lsboissard/game-store.git
    cd game-store
    ```

2. Navegue até o diretório do projeto API:
    ```bash
    cd GameStore.Api
    ```

3. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```

4. Compile o projeto:
    ```bash
    dotnet build
    ```

5. Inicie a aplicação:
    ```bash
    dotnet run
    ```

## Uso

Para usar a API, você pode utilizar ferramentas como [Postman](https://www.postman.com/) ou [curl](https://curl.se/). Veja alguns exemplos de requisições abaixo.

### Exemplo de Requisição GET

```bash
curl -X GET "http://localhost:5000/api/games"
```

## Endpoints

- `GET /api/games`: Lista todos os jogos.
- `GET /api/games/{id}`: Obtém detalhes de um jogo específico.
- `POST /api/games`: Adiciona um novo jogo.
- `PUT /api/games/{id}`: Atualiza um jogo existente.
- `DELETE /api/games/{id}`: Remove um jogo.