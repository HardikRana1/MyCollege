FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/ProHardikV1.Web.Host/ProHardikV1.Web.Host.csproj", "src/ProHardikV1.Web.Host/"]
COPY ["src/ProHardikV1.Web.Core/ProHardikV1.Web.Core.csproj", "src/ProHardikV1.Web.Core/"]
COPY ["src/ProHardikV1.Application/ProHardikV1.Application.csproj", "src/ProHardikV1.Application/"]
COPY ["src/ProHardikV1.Core/ProHardikV1.Core.csproj", "src/ProHardikV1.Core/"]
COPY ["src/ProHardikV1.EntityFrameworkCore/ProHardikV1.EntityFrameworkCore.csproj", "src/ProHardikV1.EntityFrameworkCore/"]
WORKDIR "/src/src/ProHardikV1.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/ProHardikV1.Web.Host", "src/ProHardikV1.Web.Host"]
COPY ["src/ProHardikV1.Web.Core", "src/ProHardikV1.Web.Core"]
COPY ["src/ProHardikV1.Application", "src/ProHardikV1.Application"]
COPY ["src/ProHardikV1.Core", "src/ProHardikV1.Core"]
COPY ["src/ProHardikV1.EntityFrameworkCore", "src/ProHardikV1.EntityFrameworkCore"]
WORKDIR "/src/src/ProHardikV1.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "ProHardikV1.Web.Host.dll"]
