﻿# Dotnet microservice template

This template provides the means for creating a self-contained dotnet microservice to be used in the context of an application using the microservice architectural pattern.

It was designed to work with the igia platform, an open-source digital health platform built by Partners Healthcare in collaboration with Persistent Systems. It also works well with jHipster microservices applications.

For more information on igia see <https://igia.github.io>.

For more information on jHipster see: <https://www.jhipster.tech>.

## Microservice architecture

Microservice architecture is a design pattern used to build an application using self-contained distributed services.

## Installing the Template

In order to use any dotnet new template it must first be installed. To install this template run the following command.

```bash
dotnet new -i _template_name_
```

## Uninstalling or updating the template

In order to update the template, first uninstall the existing template then run the install command again.

```bash
dotnet new -u _template_name_
dotnet new -i _template_name_
```

## Template Capabilities

- Netflix Eureka registration

    Eureka Server provides a place to register your microservice instance(s) so that your application can discover them. Eureka will handle routing and load-balancing. Eureka registry support is prover bt the Steeltoe library: <https://www.nuget.org/packages/Steeltoe.Discovery.ClientCore>

- Spring Cloud Config Server

    Spring Cloud provides configuration settings during runtime. Spring Cloud configuration is provided by the Steeltoe library: <https://www.nuget.org/packages/Steeltoe.Extensions.Configuration.ConfigServerCore/>

- Swagger

    Swagger provides a user interface to test your micro-service. Swagger support is provided by the Swashbuckle library: <https://www.nuget.org/packages/Swashbuckle.AspNetCore>

## Tested with jHipster

This template can theoretically support a variety of micro-service platforms but the preferred micro-services platform is jHipster. For more information on jHipster see: <https://www.jhipster.tech>.

## Running the microservice

The microservice runs in two modes Default Mode, Docker Mode, Standalone Mode. Unless running locally, your microservice should only run in Default mode. The following environment variables are configurable in the microservice.

### Environment Variables

| Environment Variable                        | Description                                                                                                                                                                                                                                                                                                                    |
| ------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **CONFIGURATION_NAME**                      | To run in standalone mode set this value STANDALONE. If not set to standalone it will run in Default mode.                                                                                                                                                                                                                    |
| **PORT**                                    | The port to listen for http traffic.                                                                                                                                                                                                                                                                                           |
| **SPRING__CLOUD__CONFIG__URI**              | *Converts to required spring variable: spring:cloud:config:uri*.  The url to the Spring Cloud Config Server using the format. The format of the url includes the username and password used to connect to the config server. For example when running the default jHipster registry <http://admin:admin@localhost:8761/config> |
| **SPRING__APPLICATION__NAME**               | *Converts to required spring variable: spring:application:name*. The name of the service used during registration is automatically set to the project name during solution creation.                                                                                                                                                  |
| **SPRING__CLOUD__CONFIG__ENV**              | *Converts to required spring variable: spring:cloud:config:env*.  The name of the configuration environment to use.                                                                                                                                                                                                            |
| **SPRING__PROFILES__ACTIVE**                | *Converts to required spring variable: spring:profiles:active*.                                                                                                                                                                                                                                                                |
| **EUREKA__INSTANCE__PORT**                  | *Converts to required spring variable: spring:instance:port*.   The port to listen for http traffic.                                                                                                                                                                                                                           |
| **SPRING__CLOUD__CONFIG__LABEL**            | *Converts to required spring variable: spring:cloud:config:label*.                                                                                                                                                                                                                                                             |
| **EUREKA__CLIENT__SERVICEURL__DEFAULTZONE** | *Converts to required spring variable: spring:client:serviceUrl:defaultZone*. The url to the Eureka server. The url format includes the username and password used to connect to the eureka server.   For example when running the default jHipster register <http://admin:admin@localhost:8761/config>                         |

*Note: In the dotnet environment the double underscore (__) is changed to the colon (:). This conversion is required by Spring.*

### Execution Modes

- __**Standalone Mode**__

Provides a way to develop and test your microservice without running a Eureka Registry and Spring Config Server. 

To run:

1. Select the Standalone Configuration Environment
2. Set CONFIGURATION_NAME environment variable to "STANDALONE"
3. Set PORT environment variable to an unused port. ex. 8081
4. Run the project.
5. Navigate to <http://localhost:[PORT}/swagger>. Change PORT to the PORT selected above.
   - ex <http://localhost:8081/swagger>

- __**Default Mode**__

This mode requires registration and configuration. The following environment variables need to be set when running in Default mode.

- __**Docker Mode**__
  
A local Docker Desktop installation is required <https://www.docker.com/products/docker-desktop>. Running in this mode, creates a image and runs a container of the image in docker.