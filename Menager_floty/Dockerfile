FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Menager_floty/Menager_floty.csproj", "Menager_floty/"]
COPY ["DAL/DAL.csproj", "DAL/"]
COPY ["BLL/BLL.csproj", "BLL/"]
COPY ["Model/Model.csproj", "Model/"]
RUN dotnet restore "Menager_floty/Menager_floty.csproj"
COPY . .
WORKDIR "/src/Menager_floty"
RUN dotnet build "./Menager_floty.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS dev
ENV ASPNETCORE_ENVIRONMENT=Development
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
CMD ["dotnet", "watch", "run", "--no-launch-profile"]

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Menager_floty.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Menager_floty.dll"]
