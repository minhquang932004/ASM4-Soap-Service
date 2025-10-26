## Solution Overview

This solution is a multi-project .NET 8 application for electric vehicle management, featuring:

- **ElectricVehicleM.SoapService.QuangNM**:  
  A SOAP web service exposing endpoints for managing promotions and promotion usage. It provides two main SOAP services:
  - `PromotionsQuangNmSoapService`: Handles CRUD operations for promotions.
  - `PromotionUsageQuangNmSoapService`: Handles queries for promotion usage.

- **ElectricVehicleM.MVC.QuangNM**:  
  An ASP.NET Core MVC (Razor Pages) web application that acts as a client to the SOAP services. It allows users to view, create, edit, and delete promotions, as well as select usage information via a user-friendly web interface. The MVC app consumes the SOAP services via generated service references.

- **ElectricVehicleM.ConsoleApp.QuangNM**:  
  A .NET console application for testing and interacting with the SOAP services directly from the command line.

## SOAP Service Endpoints

- [https://localhost:7282/PromotionsQuangNmSoapService.asmx](https://localhost:7282/PromotionsQuangNmSoapService.asmx)
- [https://localhost:7282/PromotionUsageQuangNmSoapService.asmx](https://localhost:7282/PromotionUsageQuangNmSoapService.asmx)

These endpoints can be used by any compatible SOAP client to interact with the system's promotion and usage data.

## Usage

- Start the SOAP service project to host the endpoints.
- Use the MVC project for a web-based management interface.
- Use the ConsoleApp project for command-line testing and automation.

---