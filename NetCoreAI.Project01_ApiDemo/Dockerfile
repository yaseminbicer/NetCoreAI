#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NetCoreAI.Project01_ApiDemo/NetCoreAI.Project01_ApiDemo.csproj", "NetCoreAI.Project01_ApiDemo/"]
RUN dotnet restore "NetCoreAI.Project01_ApiDemo/NetCoreAI.Project01_ApiDemo.csproj"
COPY . .
WORKDIR "/src/NetCoreAI.Project01_ApiDemo"
RUN dotnet build "NetCoreAI.Project01_ApiDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreAI.Project01_ApiDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreAI.Project01_ApiDemo.dll"]
