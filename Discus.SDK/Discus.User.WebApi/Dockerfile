#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Discus.User.WebApi/Discus.User.WebApi.csproj", "Discus.User.WebApi/"]
COPY ["Discus.Shared.Webapi/Discus.Shared.WebApi.csproj", "Discus.Shared.Webapi/"]
COPY ["Discus.SDK.Consul/Discus.SDK.Consul.csproj", "Discus.SDK.Consul/"]
COPY ["Discus.SDK.Core/Discus.SDK.Core.csproj", "Discus.SDK.Core/"]
COPY ["Discus.SDK.Redis/Discus.SDK.Redis.csproj", "Discus.SDK.Redis/"]
COPY ["Discus.SDK.Tools/Discus.SDK.Tools.csproj", "Discus.SDK.Tools/"]
COPY ["Discus.Shared/Discus.Shared.csproj", "Discus.Shared/"]
COPY ["Discus.User.Application.Contracts/Discus.User.Application.Contracts.csproj", "Discus.User.Application.Contracts/"]
COPY ["Discus.Shared.Application.Contracts/Discus.Shared.Application.Contracts.csproj", "Discus.Shared.Application.Contracts/"]
COPY ["Discus.User.Repository/Discus.User.Repository.csproj", "Discus.User.Repository/"]
COPY ["Discus.SDK.Repository.SqlSuger/Discus.SDK.Repository.SqlSugar.csproj", "Discus.SDK.Repository.SqlSuger/"]
COPY ["Discus.User.Application/Discus.User.Application.csproj", "Discus.User.Application/"]
COPY ["Discus.Shared.Application/Discus.Shared.Application.csproj", "Discus.Shared.Application/"]
COPY ["Discus.SDK.File/Discus.SDK.File.csproj", "Discus.SDK.File/"]
COPY ["Discus.SDK.IdGenerater/Discus.SDK.IdGenerater.csproj", "Discus.SDK.IdGenerater/"]
COPY ["Discus.SDK.RabbitMQ/Discus.SDK.RabbitMQ.csproj", "Discus.SDK.RabbitMQ/"]
COPY ["Discus.Shared.Repository/Discus.Shared.Repository.csproj", "Discus.Shared.Repository/"]
RUN dotnet restore "Discus.User.WebApi/Discus.User.WebApi.csproj"
COPY . .
WORKDIR "/src/Discus.User.WebApi"
RUN dotnet build "Discus.User.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Discus.User.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Discus.User.WebApi.dll"]