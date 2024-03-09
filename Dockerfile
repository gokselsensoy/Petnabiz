FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /Petnabiz
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /Petnabiz
EXPOSE 80
COPY --from=build-env /Petnabiz/out .

ENTRYPOINT ["dotnet", "WebAPI.dll"]