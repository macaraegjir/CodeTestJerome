# CodeTest Coding Exercise
by Jerome Macaraeg  

### Architecture and Tech Used
* Asp.net MVC
* Entity Framework
* Restful API


### Installation

Make sure you have Visual Studio 2019 installed and install the following packages
* EntityFramework
* Microsoft.AspNet.Mvc
* NUnit

### Excecution
To test the application make sure you have Postman installed(https://www.postman.com/downloads/)
1. Press F5 in Visual Studio to run the application
2. Copy the URL from the browser that will popup to Postman and append this "api/accounts/GetAccountPaymentDetails/" 
(eg. https://localhost:44365/api/accounts/GetAccountPaymentDetails/{Accountno})
3. Press Send

### Testing Data
Account nos. available
* 10000001
* 10000002
* 10000003

Length of Account number should be 8 digits and should only contain numbers


###Comments
* I assumed that the Status field is on the Account level not the payment level
* 
