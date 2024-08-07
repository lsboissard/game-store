﻿using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GameEndpoints {
  private static readonly List<GameDto> games =
  [
    new(1, "Street Fighter II", "Fighting", 19.9M, new DateOnly(1992, 7, 15)),
    new(2, "Final Fantasy XIV", "Roleplaying", 59.99M, new DateOnly(2010, 9, 30)),
    new(3, "FIFA 23", "Sports", 69.99M, new DateOnly(2022, 9, 27))
  ];

  public static WebApplication MapGamesEndpoints(this WebApplication app) {
    //GET /games
    app.MapGet("games", () => games).WithName("GetAllGames");

    //GET /games/1
    app.MapGet(
        "games/{id}",
        (int id) => {
          GameDto? game = games.Find(game => game.Id == id);
          return game is null ? Results.NotFound() : Results.Ok(game);
        }
      )
      .WithName("GetGame");

    //POST /games
    app.MapPost(
        "games",
        (CreateGameDto newGame) => {
          GameDto game =
            new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price, newGame.ReleaseDate);

          games.Add(game);

          return Results.CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }
      )
      .WithName("CreateGame")
      .WithParameterValidation();

    //PUT /games/1
    app.MapPut(
        "games/{id}",
        (int id, UpdateGameDto updatedGame) => {
          var index = games.FindIndex(game => game.Id == id);

          if (index == -1) {
            return Results.NotFound();
          }

          games[index] = new GameDto(
            id,
            updatedGame.Name,
            updatedGame.Genre,
            updatedGame.Price,
            updatedGame.ReleaseDate
          );

          return Results.NoContent();
        }
      )
      .WithName("UpdateGame")
      .WithParameterValidation();

    //DELETE /games/1
    app.MapDelete(
        "games/{id}",
        (int id) => {
          games.RemoveAll(game => game.Id == id);

          return Results.NoContent();
        }
      )
      .WithName("DeleteGame");

    app.MapGet("/", () => "...");

    return app;
  }
}
