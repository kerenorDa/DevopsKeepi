# שלב 1: בסיס עבור ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /src
EXPOSE 80
EXPOSE 443

# שלב 2: Build
COPY ["Server/Keepi.Server.csproj", "Server/"]
COPY ["Shared/Keepi.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Keepi.Server.csproj"

COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Keepi.Server.csproj" -c Release -o /app/build

# שלב 3: Tests
FROM base AS tests
WORKDIR /src
RUN dotnet test --logger "trx;LogFileName=TestResults.trx"

# שלב 4: פרסום (Publish)
FROM base AS publish
WORKDIR /src/Server
RUN dotnet publish "Keepi.Server.csproj" -c Release -o /app/publish

# שלב 5: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=tests /src/TestResults/ . # שמירת תוצאות הבדיקות
ENTRYPOINT ["dotnet", "Keepi.Server.dll"]
