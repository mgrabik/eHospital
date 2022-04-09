#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConnectDoctor.REST/ConnectDoctor.REST.csproj", "ConnectDoctor.REST/"]
COPY ["ConnectDoctor.Model/ConnectDoctor.Model.csproj", "ConnectDoctor.Model/"]
COPY ["ConnectDoctor.Logic/ConnectDoctor.Logic.csproj", "ConnectDoctor.Logic/"]
RUN dotnet restore "ConnectDoctor.REST/ConnectDoctor.REST.csproj"
COPY . .
WORKDIR "/src/ConnectDoctor.REST"
RUN dotnet build "ConnectDoctor.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConnectDoctor.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConnectDoctor.REST.dll"]