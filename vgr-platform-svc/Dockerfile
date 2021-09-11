#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["vgr-platform-svc/vgr-platform-svc.csproj", "vgr-platform-svc/"]
RUN dotnet restore "vgr-platform-svc/vgr-platform-svc.csproj"
COPY . .
WORKDIR "/src/vgr-platform-svc"
RUN dotnet build "vgr-platform-svc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "vgr-platform-svc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "vgr-platform-svc.dll"]