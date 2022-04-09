#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Prescription.Rest/Prescription.Rest.csproj", "Prescription.Rest/"]
COPY ["Prescription.Model/Prescription.Model.csproj", "Prescription.Model/"]
COPY ["Prescription.Logic/Prescription.Logic.csproj", "Prescription.Logic/"]
COPY ["Prescription.Tests/Prescription.Tests.csproj", "Prescription.Tests/"]

RUN dotnet restore "Prescription.Rest/Prescription.Rest.csproj"
COPY . .
WORKDIR "/src/Prescription.Rest"
RUN dotnet build "Prescription.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Prescription.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Prescription.Rest/Prescription.xml .
COPY Prescription.Rest/PrescritionSchema.xsd .
ENTRYPOINT ["dotnet", "Prescription.Rest.dll"]