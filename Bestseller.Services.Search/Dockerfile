#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Bestseller.Services.Search/Bestseller.Services.Search.csproj", "Bestseller.Services.Search/"]
RUN dotnet restore "Bestseller.Services.Search/Bestseller.Services.Search.csproj"
COPY . .
WORKDIR "/src/Bestseller.Services.Search"
RUN dotnet build "Bestseller.Services.Search.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bestseller.Services.Search.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bestseller.Services.Search.dll"]