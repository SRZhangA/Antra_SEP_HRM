#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Recruiting.API/", "src/Services/Recruiting/Recruiting.API/"]
COPY ["ApplicationCore/", "src/Services/Recruiting/ApplicationCore/"]
COPY ["Infrastructure/", "src/Services/Recruiting/Infrastructure/"]
RUN dotnet restore "src/Services/Recruiting/Recruiting.API/Recruiting.API.csproj"
WORKDIR "/src/src/Services/Recruiting/Recruiting.API"
RUN dotnet build "Recruiting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruiting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Recruiting.API.dll"]