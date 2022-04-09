# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
COPY . /app
WORKDIR /app/Prescription.Rest
RUN dotnet restore "./Prescription.Rest.csproj"
RUN dotnet build "./Prescription.Rest.csproj" 
RUN dotnet publish -c Release -o published
WORKDIR /app/Prescription.Rest/published
ENTRYPOINT ["dotnet", "Prescription.Rest.dll", "--urls", "https://0.0.0.0:8083"]
