# Zip File Extractor

This application allows you to extract a specific file from a ZIP archive without preserving directory levels. It uses the **IPWorksZip** library and requires a valid runtime license for execution.

---

## Prerequisites

- **.NET SDK 8.0**: Make sure .NET SDK is installed on your machine.
- **IPWorksZip License**: Obtain a valid license for the IPWorksZip library.

---

## Setting Up the License

Before running the application, ensure that the license key is added to the code.

```csharp
zip.RuntimeLicense = "your-license-key-here";
