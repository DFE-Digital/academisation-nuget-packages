namespace Dfe.Academisation.ExtensionMethods.Tests;
using System.ComponentModel;
/// <summary>
/// The example enum.
/// </summary>

public enum ExampleEnum
{
    [Description("Regional Director for the region")] DescriptionWithSpaces,
    [Description("DescriptionWithOneWord")] DescriptionWithOneWord,
    [Description("")] EmptyDescription,
    [Description(" ")] WhiteSpaceDescription,
    [Description(default)] NullDescription,
    NoDescription,

}