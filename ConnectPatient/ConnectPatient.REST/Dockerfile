#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ConnectPatient.REST/ConnectPatient.REST.csproj", "ConnectPatient.REST/"]
COPY ["ConnectPatient.Logic/ConnectPatient.Logic.csproj", "ConnectPatient.Logic/"]
COPY ["ConnectPatient.Model/ConnectPatient.Model.csproj", "ConnectPatient.Model/"]
RUN dotnet restore "ConnectPatient.REST/ConnectPatient.REST.csproj"
COPY . .
WORKDIR "/src/ConnectPatient.REST"
RUN dotnet build "ConnectPatient.REST.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConnectPatient.REST.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConnectPatient.REST.dll"]