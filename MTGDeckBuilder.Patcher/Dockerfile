#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MTGDeckBuilder/MTGDeckBuilder.csproj", "MTGDeckBuilder/"]
COPY ["MTGDeckBuilder.DbUp/MTGDeckBuilder.DbUp.csproj", "MTGDeckBuilder.DbUp/"]
COPY ["MTGDeckBuilder.EF/MTGDeckBuilder.EF.csproj", "MTGDeckBuilder.EF/"]
COPY ["MTGDeckBuilder.Core/MTGDeckBuilder.Core.csproj", "MTGDeckBuilder.Core/"]
COPY ["MTGDeckBuilder.Services/MTGDeckBuilder.Services.csproj", "MTGDeckBuilder.Services/"]
RUN dotnet restore "MTGDeckBuilder/MTGDeckBuilder.csproj"
COPY . .
WORKDIR "/src/MTGDeckBuilder"
RUN dotnet build "MTGDeckBuilder.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MTGDeckBuilder.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MTGDeckBuilder.dll"]