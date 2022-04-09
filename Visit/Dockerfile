# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . /app
WORKDIR /app/Visit.Rest2
RUN dotnet restore "./Visit.Rest.csproj"
RUN dotnet build "./Visit.Rest.csproj" 
RUN dotnet publish -c Release -o published
WORKDIR /app/Visit.Rest2/published
ENTRYPOINT ["dotnet", "Visit.Rest.dll", "--urls", "https://0.0.0.0:8082"]
