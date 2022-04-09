# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . /app
WORKDIR /app/ConnectPatient.REST
RUN dotnet restore "./ConnectPatient.REST.csproj"
RUN dotnet build "./ConnectPatient.REST.csproj"
RUN dotnet publish -c Release -o published
WORKDIR /app/ConnectPatient.REST/published
ENTRYPOINT ["dotnet", "ConnectPatient.REST.dll", "--urls", "https://0.0.0.0:8081"]
