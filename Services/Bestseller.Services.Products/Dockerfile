#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Bestseller.Services.Products/Bestseller.Services.Products.csproj", "Services/Bestseller.Services.Products/"]
RUN dotnet restore "Services/Bestseller.Services.Products/Bestseller.Services.Products.csproj"
COPY . .
WORKDIR "/src/Services/Bestseller.Services.Products"
RUN dotnet build "Bestseller.Services.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bestseller.Services.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bestseller.Services.Products.dll"]