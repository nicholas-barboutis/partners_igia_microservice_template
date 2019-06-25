FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE $EUREKA_INSTANCE_PORT
COPY publish ./
#CMD tail -f /dev/null
ENTRYPOINT ["dotnet", "microservice_template.dll"]

