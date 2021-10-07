#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Services/Laboratory Information System/LIS.Grpc/LIS.Grpc.csproj", "Services/Laboratory Information System/LIS.Grpc/"]
COPY ["Services/Laboratory Information System/LIS.Service/LIS.Service.csproj", "Services/Laboratory Information System/LIS.Service/"]
COPY ["Services/Laboratory Information System/LIS.Infastructure/LIS.Infastructure.csproj", "Services/Laboratory Information System/LIS.Infastructure/"]
COPY ["EHR.SAS.Common/EHR.SAS.Common.csproj", "EHR.SAS.Common/"]
RUN dotnet restore "Services/Laboratory Information System/LIS.Grpc/LIS.Grpc.csproj"
COPY . .
WORKDIR "/src/Services/Laboratory Information System/LIS.Grpc"
RUN dotnet build "LIS.Grpc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LIS.Grpc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LIS.Grpc.dll"]
