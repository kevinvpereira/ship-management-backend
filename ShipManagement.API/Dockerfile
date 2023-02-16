FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShipManagement.API/ShipManagement.API.csproj", "ShipManagement.API/"]
COPY ["ShipManagement.Application/ShipManagement.Application.csproj", "ShipManagement.Application/"]
COPY ["ShipManagement.Domain/ShipManagement.Domain.csproj", "ShipManagement.Domain/"]
COPY ["ShipManagement.Infrastructure/ShipManagement.Infrastructure.csproj", "ShipManagement.Infrastructure/"]
RUN dotnet restore "ShipManagement.API/ShipManagement.API.csproj"
COPY . .
WORKDIR "/src/ShipManagement.API"
RUN dotnet build "ShipManagement.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShipManagement.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShipManagement.API.dll"]
