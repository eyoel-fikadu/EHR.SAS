#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Billing System/Billing.API/Billing.API.csproj", "Services/Billing System/Billing.API/"]
COPY ["Services/Billing System/Billing.Service/Billing.Service.csproj", "Services/Billing System/Billing.Service/"]
COPY ["Services/Billing System/Billing.DataLayer/Billing.Infastructure.csproj", "Services/Billing System/Billing.DataLayer/"]
COPY ["EHR.SAS.Common/EHR.SAS.Common.csproj", "EHR.SAS.Common/"]
RUN dotnet restore "Services/Billing System/Billing.API/Billing.API.csproj"
COPY . .
WORKDIR "/src/Services/Billing System/Billing.API"
RUN dotnet build "Billing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Billing.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Billing.API.dll"]
