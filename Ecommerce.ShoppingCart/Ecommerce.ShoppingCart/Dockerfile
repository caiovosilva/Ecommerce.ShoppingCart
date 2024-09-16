FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Ecommerce.ShoppingCart/Ecommerce.ShoppingCart.csproj", "Ecommerce.ShoppingCart/"]
RUN dotnet restore "Ecommerce.ShoppingCart/Ecommerce.ShoppingCart.csproj"
COPY . .
WORKDIR "/src/Ecommerce.ShoppingCart"
RUN dotnet build "Ecommerce.ShoppingCart.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Ecommerce.ShoppingCart.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.ShoppingCart.dll"]
