# ��� 1: ���� ���� ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /src
EXPOSE 80
EXPOSE 443

# ��� 2: Build
COPY ["Server/Keepi.Server.csproj", "Server/"]
COPY ["Shared/Keepi.Shared.csproj", "Shared/"]
RUN dotnet restore "Server/Keepi.Server.csproj"

COPY . .
WORKDIR "/src/Server"
RUN dotnet build "Keepi.Server.csproj" -c Release -o /app/build

# ��� 3: ����� (Publish)
FROM base AS publish
WORKDIR /src/Server
RUN dotnet publish "Keepi.Server.csproj" -c Release -o /app/publish

# ��� 4: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Keepi.Server.dll"]

