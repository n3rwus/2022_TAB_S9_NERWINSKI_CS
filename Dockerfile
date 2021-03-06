#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 4000
ENV ASPNETCORE_URLS=http://*:4000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebAlbum.csproj", "."]
RUN dotnet restore "./WebAlbum.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAlbum.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAlbum.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAlbum.dll"]