# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . /app
WORKDIR /app/ConnectDoctor.REST
RUN dotnet restore "./ConnectDoctor.REST.csproj"
RUN dotnet build "./ConnectDoctor.REST.csproj" 
RUN dotnet publish -c Release -o published
WORKDIR /app/ConnectDoctor.REST/published
ENTRYPOINT ["dotnet", "ConnectDoctor.REST.dll", "--urls", "https://0.0.0.0:8080"]
