#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MTGDeckBuilder.API/MTGDeckBuilder.API.csproj", "MTGDeckBuilder.API/"]
RUN dotnet restore "MTGDeckBuilder.API/MTGDeckBuilder.API.csproj"
COPY . .
WORKDIR "/src/MTGDeckBuilder.API"
RUN dotnet build "MTGDeckBuilder.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTGDeckBuilder.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTGDeckBuilder.API.dll"]