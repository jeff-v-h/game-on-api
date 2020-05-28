# Game On API

This API is to be used in conjunction with the Game On app. It makes requests to various third party APIs before returning the combined data.

## Getting Started

This project was made to be run in conjunction with the [backend API](https://github.com/jeffvhuang/game-on-api.git).

### Requirements

- .NET Core 2.2
- MongoDB Driver 2.9

### Third Party API Keys

You will need to register and create an API Key to be able to obtain data for each individual sport.

- [API-NBA](https://rapidapi.com/api-sports/api/api-nba)
- [API-Football](https://rapidapi.com/api-sports/api/api-football)
- [Sportradar: Tennis v2](https://developer.sportradar.com/docs/read/tennis/Tennis_v2)
- [Panda Score](https://pandascore.co/)

### Installation

- Clone the project into a directory: `git clone https://github.com/jeffvhuang/game-on-api.git`
- Navigate into the project directory: `cd game-on-api`.
- Build the solution using Visual Studio, or on the command line with `dotnet build`.
- Run the project. If using command line, run `dotnet run`.
- Use an HTTP client like Postman or Fiddler to make requests to `http://localhost:44329`.
- Check the available endpoints with the [swaggerUI in the opened browser](https://localhost:44305/index.html). Otherwise check the swagger OPEN API Specification at [/swagger/v1/swagger.json](http://localhost:44329/swagger/v1/swagger.json).

## Production

This app has been taken down from deployment due to ongoing running costs for not only hosting, but also the usage of each individual API provider.

### Deployment

N/A

## Authors

- **Jeffrey Huang** - Sole author, owner and developer. jeffvh@outlook.com
