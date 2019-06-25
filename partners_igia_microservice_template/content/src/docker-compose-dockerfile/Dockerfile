FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY microservice_template/microservice_template.csproj microservice_template/
RUN dotnet restore microservice_template/microservice_template.csproj
COPY . .
WORKDIR /src/microservice_template
RUN dotnet build microservice_template.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish microservice_template.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "microservice_template.dll"]
