FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["JustChat/JustChat.csproj", "JustChat/"]
RUN dotnet restore "JustChat/JustChat.csproj"
COPY . .
WORKDIR "/src/JustChat"
RUN dotnet build "JustChat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JustChat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JustChat.dll"]
