# Game On API

This API is to be used in conjunction with the Game On app. It makes requests to various third party APIs before returning the combined data.

## Getting Started

This project was made to be run in conjunction with the [backend API](https://github.com/jeffvhuang/game-on-api.git).

### Requirements

- .NET Core 2.2
- MongoDB Driver 2.9

### Installation

- Clone the project into a directory: `git clone https://github.com/jeffvhuang/game-on-api.git`
- Navigate into the project directory: `cd game-on-api`.
- Build the solution using Visual Studio, or on the command line with `dotnet build`.
- Run the project. If using command line, run `dotnet run`.
- Use an HTTP client like Postman or Fiddler to make requests to `http://localhost:44329`.
- Check the available endpoints with the [swaggerUI in the opened browser](https://localhost:44305/index.html). Otherwise check the swagger OPEN API Specification at [/swagger/v1/swagger.json](http://localhost:44329/swagger/v1/swagger.json).

## Production

This app is undergoing initial development and is not currently deployed.

### Deployment

N/A

## Authors

- **Jeffrey Huang** - Sole author, owner and developer. jeffvh@outlook.com
