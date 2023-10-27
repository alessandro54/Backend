# Use the official ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LevelUpCenter/LevelUpCenter.csproj", "LevelUpCenter/"]
RUN dotnet restore "LevelUpCenter/LevelUpCenter.csproj"
COPY . .
WORKDIR "/src/LevelUpCenter"
RUN dotnet build "LevelUpCenter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LevelUpCenter.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LevelUpCenter.dll"]
