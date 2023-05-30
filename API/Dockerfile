
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Kopia i przywrócenie zale¿noœci dla projektu API
COPY ["API/API.csproj", "API/"]
RUN dotnet restore "API/API.csproj"

# Kopia i przywrócenie zale¿noœci dla projektu Application (biblioteka klas)
COPY ["Application/Application.csproj", "Application/"]
RUN dotnet restore "Application/Application.csproj"

COPY . .
WORKDIR "/src/API"
RUN dotnet build "API.csproj" -c Release -o /app/build

# Kompilacja projektu Application (biblioteka klas)
WORKDIR "/src/Application"
RUN dotnet build "Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Publikacja projektu Application (biblioteka klas)
WORKDIR "/src/Application"
RUN dotnet publish "Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]