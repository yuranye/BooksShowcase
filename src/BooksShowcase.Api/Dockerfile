FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BooksShowcase.Api/BooksShowcase.Api.csproj", "BooksShowcase.Api/"]
RUN dotnet restore "BooksShowcase.Api/BooksShowcase.Api.csproj"
COPY . .
WORKDIR "/src/BooksShowcase.Api"
RUN dotnet build "BooksShowcase.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BooksShowcase.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksShowcase.Api.dll"]
