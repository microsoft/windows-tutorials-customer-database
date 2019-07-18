---
page_type: sample
languages:
- csharp
products:
- dotnet
- windows
- windows-uwp
statusNotificationTargets:
- codefirst@microsoft.com
description: "This project is the starting point for a tutorial that creates a simple app for managing a list of customers."
---

# Customer Database tutorial

This project is the starting point for a tutorial that creates a simple app for managing a list of customers. In doing so, it introduces a selection of basic concepts for enterprise apps in UWP. You'll learn how to:

* Implement Create, Read, Update, and Delete operations against a local SQL database.
* Add a data grid, to display and edit customer data in your UI.
* Arrange UI elements together in a basic form layout.

[Start the tutorial here.](https://docs.microsoft.com/windows/uwp/enterprise/customer-database-tutorial)

This starting point is a single-page app with minimal UI and functionality, based on a simplified version of the [Customer Orders Database sample app](https://github.com/Microsoft/Windows-appsample-customers-orders-database).

## Run the sample

To run this sample, [ensure you have the latest version of Visual Studio and the Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk). Once you've cloned/downloaded this repo, you can edit the project by opening **CustomerDatabaseTutorial.sln** with Visual Studio.

You can also check out the **end-point-for-reference** branch to see the completed code for this tutorial.

## Code of Interest

If you run your app immediately after opening it, you'll see a few buttons at the top of a blank screen. Though it's not visible to you, the app already includes a local SQLite database provisioned with a few test customers. From here, you'll start by implementing a UI control to display those customers, and then move on to adding in operations against the database. Before you begin, here's where you'll be working.

### Views

**CustomerListPage.xaml** is the app's View, which defines the UI for the single page in this tutorial. Any time you need to add or change a visual element in the UI, you'll do it in this file. This tutorial will walk you through adding these elements:

* A **RadDataGrid** for displaying and editing your customers. 
* A **StackPanel** to set the initial values for a new customer.

### ViewModels

**ViewModels\CustomerListPageViewModel.cs** is where the fundamental logic of the app is located. Every user action taken in the view will be passed into this file for processing. In this tutorial, you'll add some new code, and implement the following methods:

* **CreateNewCustomerAsync**, which initializes a new CustomerViewModel object.
* **DeleteNewCustomerAsync**, which removes a new customer before it's displayed in the UI.
* **DeleteAndUpdateAsync**, which handles the delete button's logic.
* **GetCustomerListAsync**, which retrieves a list of customers from the database.
* **SaveInitialChangesAsync**, which adds a new customer's information to the database.
* **UpdateCustomersAsync**, which refreshes the UI to reflect any customers added or deleted.

**CustomerViewModel** is a wrapper for a customer's information, which tracks whether or not it's been recently modified. You won't need to add anything to this class, but some of the code you'll add elsewhere will reference it.

For more information on how the sample is constructed, check out the [app structure overview](https://docs.microsoft.com/windows/uwp/enterprise/customer-database-app-structure).
