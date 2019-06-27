# Igia microservice template

This template provides the means for creating a self-contained dotnet microservice to be used in the context of an application using the microservice architectural pattern.

It was designed to work with the igia platform, an open-source digital health platform built by Partners Healthcare in collaboration with Persistent Systems. It also works well with jHipster microservices applications.

For more information on igia see <https://igia.github.io>.

For more information on jHipster see: <https://www.jhipster.tech>.

For more information on dotnet templating see: <https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates>

## Microservice architecture

Microservice architecture is a design pattern used to build an application using self-contained distributed services.

## Installing the Template

In order to use any dotnet new template it must first be installed. To install this template run the following command. This template only needs to be installed once per machine.

```bash
dotnet new -i partners_igia_microservice_template
```

## Unistalling the Template

In order to use any dotnet new template it must first be installed. To install this template run the following command.

```bash
dotnet new -u partners_igia_microservice_template
```

## Updating the template

In order to update the template, first uninstall the existing template then run the install command again.

```bash
dotnet new -u partners_igia_microservice_template
dotnet new -i partners_igia_microservice_template
```

## Create an instance of the template

Once the template installed, an new project can be created uisng the template. To create a project form the tempalte use the following command replacing project_name with your desired name.

```bash
dotnet new igia_micro --name project_name
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

The microservice runs in two modes Default Mode and Standalone Mode. Unless running locally, your microservice should only run in Default mode. The following environment variables are configurable in the microservice.

### Environment Variables

**CONFIGURATION_NAME**
To run in standalone mode set this value STANDALONE. If not set to standalone it will run in Default mode.
The port to listen for http traffic.

**EUREKA__CLIENT__SERVICEURL**
*Converts to required spring variable: spring:client:serviceUrl:defaultZone*.
The url to the Eureka server. The url format includes the username and password used to connect to the eureka server.   For example when running the default jHipster register <http://admin:admin@localhost:8761/config>

**EUREKA__INSTANCE__PORT**
*Converts to required spring variable: spring:instance:port*.
The port to listen for http traffic.

**SPRING__CLOUD__CONFIG__URI**
*Converts to required spring variable: spring:cloud:config:uri*.
The url to the Spring Cloud Config Server using the format. The format of the url includes the username and password used to connect to the config server. For example when running the default jHipster registry <http://admin:admin@localhost:8761/config>

**SPRING__APPLICATION__NAME**
*Converts to required spring variable: spring:application:name*.
The name of the service used during registration is automatically set to the project name during solution creation.

**SPRING__CLOUD__CONFIG__ENV**
*Converts to required spring variable: spring:cloud:config:env*.
The name of the configuration environment to use.

**SPRING__PROFILES__ACTIVE**
*Converts to required spring variable: spring:profiles:active*.



**SPRING__CLOUD__CONFIG__LABEL**
*Converts to required spring variable: spring:cloud:config:label*.


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

This mode attempts to register iteself to the defined registry and also attempts to retrieve configuration form the defined config server. 

To run:

1. Select the Default Configuration Environment
2. Set EUREKA__CLIENT__SERVICEURL environment variable to a Neflix Eureka Registry. If running jHipster registry locally set to: http://username:password@localhost:8761/eureka
3. Set EUREKA__INSTANCE__PORT environment variable to an used port. The microservice will be listening on this port. 
4. Set SPRING__CLOUD__CONFIG__URI environment variable to a Spring Cloud Config Server. If running jHipster registry locally set to: http://username:password@localhost:8761/config 
5. Set the following enviroment variable as desired or leave as is for default behavior(SPRING__APPLICATION__NAME, SPRING__CLOUD__CONFIG__ENV,SPRING__PROFILES__ACTIVE)
4. Run the project.
5. Navigate to <http://localhost:[EUREKA__INSTANCE__PORT}/swagger>.   

