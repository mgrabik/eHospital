#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Visit.Rest2/Visit.Rest.csproj", "Visit.Rest2/"]
COPY ["Visit.Logic/Visit.Logic.csproj", "Visit.Logic/"]
COPY ["Visit.Model/Visit.Model.csproj", "Visit.Model/"]
RUN dotnet restore "Visit.Rest2/Visit.Rest.csproj"
COPY . .
WORKDIR "/src/Visit.Rest2"
RUN dotnet build "Visit.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Visit.Rest.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY Visit.Rest2/Visits.xml .
COPY Visit.Rest2/VisitSchema.xsd .
ENTRYPOINT ["dotnet", "Visit.Rest.dll"]