# Micro Service Template Creation and Installation

The purpose of this project is to create a dotnet new template and package it for publishing to nuget. The template is published at <https://www.nuget.org/packages/igia-micro_service_template/>.

For more information on dotnet new templates see <https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates>.

For more information on packaging the dotnet template for nuget see <https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template>.

## License

[License](LICENSE.md)

## Creating a nuget package with Visual Studio for Mac

### Prerequisites

| Requirement       | Required | Description                                                  |
| ----------------- | -------- | ------------------------------------------------------------ |
| dotnet cli        | x        | Used to create the nuget package.                            |
| Visual Studio Mac | x        | Helps with editing and creating a customized nuget package.  |

To create your own customized template use the following instructions:

1. Open this project in Visual Studio for Mac. 
2. Edit as desired.
3. Update the version number on the solution.  Note: This version number is shared with the solution, the project and also nuget package.
4. When ready to create the nuget package. This will automatically install the package using dotnet cli.
5. Publish the nuget package. For instruction, see <https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package>

## Installing the Template

In order to use any dotnet new template it must first be installed. To install this template run the following command.

```bash
dotnet new -i partners_igia_microservice_template
```

## Uninstalling or Updating the template

In order to update the template, first uninstall the existing template then run the install command again.

```bash
dotnet new -u partners_igia_microservice_template
dotnet new -i partners_igia_microservice_template