FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app
COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["DataAccess/DataAccess.csproj", "DataAccess/"]
COPY ["Entities/Entities.csproj", "Entities/"]
RUN dotnet restore "WebAPI/WebAPI.csproj"
COPY . .
FROM build-env AS publish
RUN dotnet publish -c Release --property:PublishDir=/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
EXPOSE 80
COPY --from=publish /out .

ENTRYPOINT ["dotnet", "WebAPI.dll"]