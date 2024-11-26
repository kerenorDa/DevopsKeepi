# שלב 1: בסיס עבור ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app
EXPOSE 80
EXPOSE 443

# שלב 2: Build
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /src
COPY ["Server/Keepi.Server.csproj", "Server/"]
COPY ["Shared/Keepi.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Keepi.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Keepi.Server.csproj" -c Release -o /app/build

# שלב 3: פרסום (Publish)
FROM build AS publish
RUN dotnet publish "Keepi.Server.csproj" -c Release -o /app/publish

# שלב 4: Runtime
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Server.dll"]
