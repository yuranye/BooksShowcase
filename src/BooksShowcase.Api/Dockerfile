FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5134

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY src/. ./src

RUN dotnet restore "src/BooksShowcase.Api/BooksShowcase.Api.csproj"
RUN dotnet build "src/BooksShowcase.Api/BooksShowcase.Api.csproj" -c Release --no-restore -o /app/build

FROM build AS publish
RUN dotnet publish "src/BooksShowcase.Api/BooksShowcase.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksShowcase.Api.dll"]
