#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TaskTracker.WebUI/TaskTracker.WebUI.csproj", "TaskTracker.WebUI/"]
RUN dotnet restore "TaskTracker.WebUI/TaskTracker.WebUI.csproj"
COPY . .
WORKDIR "/src/TaskTracker.WebUI"
RUN dotnet build "TaskTracker.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskTracker.WebUI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskTracker.WebUI.dll"]