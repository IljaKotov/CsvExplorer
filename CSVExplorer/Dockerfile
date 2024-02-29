FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CSVExplorer/CSVExplorer.csproj", "CSVExplorer/"]
RUN dotnet restore "CSVExplorer/CSVExplorer.csproj"
COPY . .
WORKDIR "/src/CSVExplorer"
RUN dotnet build "CSVExplorer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSVExplorer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSVExplorer.dll"]
