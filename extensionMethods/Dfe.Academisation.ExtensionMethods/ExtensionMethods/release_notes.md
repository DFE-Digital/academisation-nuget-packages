# 2.0.0
Added an optional `ignoreAcronyms` argument to StringExtensions.ToSentenceCase. This defaults to true to that existing use is not impacted, but allows for the situations where you know that there are no acronyms in a string and allows them to have sentence casing applied if they are all uppercase.

(Breaking Change) Renamed Squish to SquishToLower to better represent what the string extension actually does.

Added additional extension methods used by Prepare-Transfers. 
Add extended test coverage for existing test classes and introduced new test classes/cases where completely absent.
Added better documentation on the extension methods.
Added ToHyphenated string extension
Added RemoveNonAlphanumericOrWhiteSpace string extension

# 1.2.0
Added ToFirstUpper string extension. Uppercases the first character of a string.

# 1.0.0
Initial version with extension methods take from the Prepare project that are generic enough to be made available for reuse in other applications.
