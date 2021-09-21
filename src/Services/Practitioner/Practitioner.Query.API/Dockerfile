#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Practitioner/Practitioner.Query.API/Practitioner.Query.API.csproj", "Services/Practitioner/Practitioner.Query.API/"]
COPY ["Services/Practitioner/Practitioner.Infrastructure/Practitioner.Infrastructure.csproj", "Services/Practitioner/Practitioner.Infrastructure/"]
COPY ["Services/Practitioner/Practitioner.Domain/Practitioner.Domain.csproj", "Services/Practitioner/Practitioner.Domain/"]
COPY ["EHR.SAS.Common/EHR.SAS.Common.csproj", "EHR.SAS.Common/"]
COPY ["Services/Practitioner/Practitioner.Application/Practitioner.Application.csproj", "Services/Practitioner/Practitioner.Application/"]
RUN dotnet restore "Services/Practitioner/Practitioner.Query.API/Practitioner.Query.API.csproj"
COPY . .
WORKDIR "/src/Services/Practitioner/Practitioner.Query.API"
RUN dotnet build "Practitioner.Query.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Practitioner.Query.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Practitioner.Query.API.dll"]
