#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Src/CompanyName.ProjectName.WebApi/CompanyName.ProjectName.WebApi.csproj", "Src/CompanyName.ProjectName.WebApi/"]
COPY ["Src/CompanyName.ProjectName.Application/CompanyName.ProjectName.Application.csproj", "Src/CompanyName.ProjectName.Application/"]
COPY ["Src/CompanyName.ProjectName.Persistence/CompanyName.ProjectName.Persistence.csproj", "Src/CompanyName.ProjectName.Persistence/"]
COPY ["Src/CompanyName.ProjectName.Domain/CompanyName.ProjectName.Domain.csproj", "Src/CompanyName.ProjectName.Domain/"]
COPY ["Src/CompanyName.ProjectName.Infrastructure/CompanyName.ProjectName.Infrastructure.csproj", "Src/CompanyName.ProjectName.Infrastructure/"]
RUN dotnet restore "Src/CompanyName.ProjectName.WebApi/CompanyName.ProjectName.WebApi.csproj"
COPY . .
WORKDIR "/src/Src/CompanyName.ProjectName.WebApi"
RUN dotnet build "CompanyName.ProjectName.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyName.ProjectName.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyName.ProjectName.WebApi.dll"]