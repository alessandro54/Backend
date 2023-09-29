# Level Up Center API

## Technologies

| Technology | Version | Purpose       |
| ---------- | ------- | ------------- |
| .NET       | 6.0     | Runtime       |
| ASP.NET    | 6.0     | Web Framework |
| MySQL      | 8.x     | Database      |

# Usage

```shell
cd LevelUpCenter
```
Then fill with the correct env variables such the database connection string.
```sh
dotnet build
```

*This app uses MySQL so you need to set the connection string in `ASPNETCORE_DATABASE_STRING` variable*

```sh
dotnet run
```

## Test the connection
```sh
curl http://localhost:5215/
# {"time":"2023-09-28T21:25:33.355416-05:00","greet":"Hello, World!"}
```

