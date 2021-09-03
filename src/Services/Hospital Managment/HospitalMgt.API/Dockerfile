#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Hospital Managment/HospitalMgt.API/HospitalMgt.API.csproj", "Services/Hospital Managment/HospitalMgt.API/"]
COPY ["Services/Hospital Managment/Hospital_Mgt.Application/HospitalMgt.Application.csproj", "Services/Hospital Managment/Hospital_Mgt.Application/"]
COPY ["Services/Hospital Managment/Hospital_Mgt.Domain/HospitalMgt.Domain.csproj", "Services/Hospital Managment/Hospital_Mgt.Domain/"]
COPY ["EHR.SAS.Common/EHR.SAS.Common.csproj", "EHR.SAS.Common/"]
COPY ["Services/Hospital Managment/HospitalMgt.Infrastructure/HospitalMgt.Infrastructure.csproj", "Services/Hospital Managment/HospitalMgt.Infrastructure/"]
RUN dotnet restore "Services/Hospital Managment/HospitalMgt.API/HospitalMgt.API.csproj"
COPY . .
WORKDIR "/src/Services/Hospital Managment/HospitalMgt.API"
RUN dotnet build "HospitalMgt.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HospitalMgt.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HospitalMgt.API.dll"]
