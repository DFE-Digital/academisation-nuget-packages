# academisation-nuget-packages

This repository is a mono-repo and contains a number of different nuget packages used by the academisation process - A2B, Prepare Transfers and Prepare Conversions.

Each package folder contains it's own solution file and each package has it's own github workflows.
See the readme files within each folder for details on the individual packages.

## To Add new Nuget Packages

* Create a sub-folder for your package and make sure that this folder contains all of the files your package needs (except for GitHub workflows files), and that you don't rely on any files outside of this folder to build the package.


* Create your Nuget package in this folder
    * Nuget packages are created from dotnet Class Libraries.
    * If you are using other C# projects for reference, make sure that you do not copy any Package Identifiers. These must be unique for each package.

    * Nuget packages have their own versioning rules, make sure you understand them. See [this article for info](https://learn.microsoft.com/en-gb/nuget/concepts/package-versioning).
    * In the properties for your class library set the following
      
      * Generate NuGet package on build - suggested value: *`ticked`*
      
      * Package ID - suggested value: `$(AssemblyName)`
      
      * Title - set this to a user friendly title, it will be shown on by tools such as NuGet Package Manager
      
      * Package Version - A version number in the format of *Major.Minor.Patch* with an optional release suffix. [this article for info](https://learn.microsoft.com/en-gb/nuget/concepts/package-versioning)
      
      * Authors - suggested value: `DFE-Digital`
      
      * Project Url - This should be the path to the sub folder of your nuget package, within this repository. Suggested value: `https://github.com/DFE-Digital/academisation-nuget-packages/tree/main/[Your Sub-Folder]`
      
      * ReadME - This should be a path to a ReadMe file explaining the purpose of your Package and how to use it. It is not the path to this file. Provide a ReadMe file in the sub-folder for your package. Suggested value: `..\README.md`
      
      * Repository Url - This is the URL to the GitHub repository hosting the package source. The URL should be to the root of this repository. Suggested value: `https://github.com/DFE-Digital/academisation-nuget-packages`
      
      * Repository Type - The type of repository. By default it will be Git but it's recommended that you explicitly declare this. Suggested Value: `git`
      
      * Tag - a semi-colon delimited list of tags to associate with your NuGet package. In addition to your own, it's recommended that you use the following `dfe;academisation`

* Create a new workflow file in the `.github/workflows` folder to build your nuget package and push it to GitHub. This workflow will be specifically for your packagage so name it appropriately, something like `[Your Package Name]-build-and-push-package.yml`.

> An example workflow file has been provided to make it easier for you to integrate with GitHub actions. The example workflow will build your nuget packages in release mode and apply the package version from the C# project belonging to the package. You must make sure you maintain the version number of the package for everything to work correctly.
  
* Use the `example-workflow.yml` file as a template to create your new work flow. Make sure that you replace all of the placeholders with information unique to your nuget package.
The placeholder values are within square parenthesis (`[]`) for example `[NameOfYourPackage]`
