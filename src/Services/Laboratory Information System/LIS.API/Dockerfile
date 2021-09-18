#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Laboratory Information System/LIS.API/LIS.API.csproj", "Services/Laboratory Information System/LIS.API/"]
COPY ["Services/Laboratory Information System/LIS.Service/LIS.Service.csproj", "Services/Laboratory Information System/LIS.Service/"]
COPY ["Services/Laboratory Information System/LIS.Infastructure/LIS.Infastructure.csproj", "Services/Laboratory Information System/LIS.Infastructure/"]
COPY ["EHR.SAS.Common/EHR.SAS.Common.csproj", "EHR.SAS.Common/"]
RUN dotnet restore "Services/Laboratory Information System/LIS.API/LIS.API.csproj"
COPY . .
WORKDIR "/src/Services/Laboratory Information System/LIS.API"
RUN dotnet build "LIS.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LIS.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LIS.API.dll"]