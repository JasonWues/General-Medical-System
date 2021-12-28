#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["General Medical System Webapi/General Medical System Webapi.csproj", "General Medical System Webapi/"]
COPY ["IGeneralMedicalDal/IGeneralMedicalDal.csproj", "IGeneralMedicalDal/"]
COPY ["Entity/Entity.csproj", "Entity/"]
COPY ["IGeneralMedicalBll/IGeneralMedicalBll.csproj", "IGeneralMedicalBll/"]
COPY ["GeneralMedicalBll/GeneralMedicalBll.csproj", "GeneralMedicalBll/"]
COPY ["Utility/Utility.csproj", "Utility/"]
COPY ["GeneralMedicalDal/GeneralMedicalDal.csproj", "GeneralMedicalDal/"]
RUN dotnet restore "General Medical System Webapi/General Medical System Webapi.csproj"
COPY . .
WORKDIR "/src/General Medical System Webapi"
RUN dotnet build "General Medical System Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "General Medical System Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "General Medical System Webapi.dll"]