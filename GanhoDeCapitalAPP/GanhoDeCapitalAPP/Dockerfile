#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GanhoDeCapitalAPP/GanhoDeCapitalAPP.csproj", "GanhoDeCapitalAPP/"]
RUN dotnet restore "GanhoDeCapitalAPP/GanhoDeCapitalAPP.csproj"
COPY . .
WORKDIR "/src/GanhoDeCapitalAPP"
RUN dotnet build "GanhoDeCapitalAPP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet test "GanhoDeCapitalAPP.csproj" -c Release -o /app/publish
RUN dotnet publish "GanhoDeCapitalAPP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GanhoDeCapitalAPP.dll"]