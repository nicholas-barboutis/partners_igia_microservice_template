# Igia Microservice template creation and installation

The purpose of this project is to create a dotnet new template and package it for publishing to NuGet.  

This project was used to create and publish a template located at <https://www.nuget.org/packages/partners_igia_microservice_template/>.

For more information on dotnet new templates see <https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates>.

For more information on igia see <https://igia.github.io>.

For more information on packaging the dotnet template for NuGet see <https://docs.microsoft.com/en-us/dotnet/core/tutorials/create-custom-template>.

For more information on .NET Core see <https://docs.microsoft.com/en-us/dotnet/core/get-started>.

## License

The project is made available under the [MIT License](LICENSE.md).

## Using this NuGet template

For instructions on using this template see this [README](<https://github.com/nicholas-barboutis/partners_igia_microservice_template/blob/master/partners_igia_microservice_template/content/src/microservice_template/README.md>)

## Creating a NuGet package with Visual Studio for Mac

### Prerequisites

| Requirement              | Required | Description                                        |
| ------------------------ | -------- | -------------------------------------------------- |
| dotnet cli               | x        | Used to create the NuGet package                   |
| Visual Studio Mac        | x        | Required for editing and creating a NuGet package. |
| .Net Core 2.2 or greater | x        | Required .NET core framework.                      |

## Installing the template

In order to use any dotnet new template it must first be installed. To install this template run the following command.

```bash
dotnet new -i partners_igia_microservice_template
```

## Uninstalling or updating the template

In order to update the template, first uninstall the existing template then run the install command again.

```bash
dotnet new -u partners_igia_microservice_template
dotnet new -i partners_igia_microservice_template
```

## Customizing this template

While the template can be used out of the box, you can also further customize it for your needs. To create a customized template, use the following instructions:

1. Download or fork this project.
2. Open the project in Visual Studio for Mac.
3. Edit the project as desired.
4. Once completed, create the NuGet package. (This will automatically install the package locally using dotnet cli)
5. Before publishing to NuGet, update the version number in the solution.  Note: This version number is automatically shared with the solution, project and NuGet package.
6. Publish the NuGet package. For instructions, see <https://docs.microsoft.com/en-us/nuget/create-packages/publish-a-package>