FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS watch
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]

WORKDIR /app

VOLUME ["/app"]

EXPOSE 5000
