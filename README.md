# SuperFormulaRestAPI

> SuperFormaulaRestAPI V1.

Super Formlua REST API V1 allows creation of new policies, addition of policies to existing members, retrieval of a specific policy based on policy id and member's driver license number.

> ###### API Base Url: https://superformularestapi20220601225621.azurewebsites.net/
> ###### Swagger Definition URL: https://superformularestapi20220601225621.azurewebsites.net/swagger/index.html

```plaintext
Create a Policy endpoint: api/policy/create (Request type: POST)
```

Request Body attributes:

| Attribute                | Type     | Required               | Description           |
|:-------------------------|:---------|:-----------------------|:----------------------|
| `effectiveDate` | DateTime | Yes | Date when the insurance policy goes into effect. Must be atleast 30 days from policy creation date. |
| `firstName` | string | Yes | Member's first name. |
| `LastName` | string | Yes | Member's last name. |
| `driverLicenseNumber`| string | Yes | Member's alpha numeric driver license number. |
| `vehicleYear` | int | Yes | Vehicle year. |
| `vehicleModel` | string | Yes | Vehicle model. |
| `vehicleManufacturer`| string | Yes | Vehicle manufacturer. |
| `vehicleName` | string | Yes | Member provided name to identify their vehicles. |
| `streetAddress` | string | Yes | Member's street address. Must be valid US address |
| `city`| string | Yes | Member's city. Must be a valid US city |
| `state`| string | Yes | Member's state. Must be a valid US state |
| `zip`| string | Yes | Member's zip code. Must be a valid US zip |
| `expirationDate`| DateTime | Yes | Policy expiration date. |
| `premium`| double | Yes | Policy monthly cost. |


Response body attributes:

| Attribute                | Type     | Description           |
|:-------------------------|:---------|:----------------------|
| `Message` | string | Response message detail. |

Example request:

```shell
curl -X 'POST' \
  'https://localhost:7018/api/policy/create' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
  "effectiveDate": "2022-06-30T22:43:24.999Z",
  "firstName": "John",
  "lastName": "Wick",
  "driverLicenseNumber": "DL901125",
  "vehicleYear": 1965,
  "vehicleModel": "Camry",
  "vehicleManufacturer": "Toyota",
  "vehicleName": "My Car",
  "streetAddress": "4547 41st Ave",
  "city": "Woodside",
  "state": "NY",
  "zip": "11313",
  "expirationDate": "2022-07-30T22:43:24.999Z",
  "premium": 89.50
}'
```

Example response:

```
Policy Created
```

```plaintext
Retrieve all policies of a member endpoint: api/policy/getpolicy/{dlNum} (Request type: GET)
{dlNum} Member Driver License number is required!
```
Request Parameters:

| Parameter                | Type     | Required               | Description           |
|:-------------------------|:---------|:-----------------------|:----------------------|
| `sort` | string => (asc or desc) | No | Allows sorting policies of a member ascending or descending based on the vehicle year. |
| `includeExpired` | boolean | No | Allows filtering expired policies from the response body. |

Response body attributes:

| Attribute                | Type     | Description           |
|:-------------------------|:---------|:----------------------|
| `effectiveDate` | DateTime | Effective date of the insurance policy. |
| `firstName` | string | Member's first name. |
| `LastName` | string | Member's last name. |
| `driverLicenseNumber`| string | Member's alpha numeric driver license number. |
| `vehicleYear` | int | Vehicle year. |
| `vehicleModel` | string | Vehicle model. |
| `vehicleManufacturer`| string | Vehicle manufacturer. |
| `vehicleName` | string | Member provided name to identify their vehicles. |
| `streetAddress` | string | Member's street address. Must be valid US address |
| `city`| string | Member's city. Must be a valid US city |
| `state`| string | Member's state. Must be a valid US state |
| `zip`| string | Member's zip code. Must be a valid US zip |
| `expirationDate`| DateTime | Policy expiration date. |
| `premium`| double | Policy monthly cost. |

Example request:

```shell
curl -X 'GET' \
  'https://localhost:7018/api/policy/getpolicy/DL1000003?sort=asc&includeExpired=false' \
  -H 'accept: */*'
```

Example response:

```
[
  {
    "effectiveDate": "2022-06-24T20:54:45.9774839",
    "firstName": "Tony",
    "lastName": "Stark",
    "driverLicenseNumber": "DL1000003",
    "vehicleYear": 1955,
    "vehicleModel": "Focus",
    "vehicleManufacturer": "Ford",
    "vehicleName": "My Car",
    "streetAddress": "300 S RANKIN ST",
    "city": "RICHMOND",
    "state": "VA",
    "zip": "23224",
    "expirationDate": "2022-11-25T20:54:45.9774841",
    "premium": 80.95
  },
  {
    "effectiveDate": "2022-06-24T20:54:45.977482",
    "firstName": "Tony",
    "lastName": "Stark",
    "driverLicenseNumber": "DL1000003",
    "vehicleYear": 1966,
    "vehicleModel": "Corolla",
    "vehicleManufacturer": "Toyota",
    "vehicleName": "My Car",
    "streetAddress": "300 S RANKIN ST",
    "city": "RICHMOND",
    "state": "VA",
    "zip": "23224",
    "expirationDate": "2022-11-25T20:54:45.9774821",
    "premium": 80.95
  },
  {
    "effectiveDate": "2022-06-24T20:54:45.9774845",
    "firstName": "Tony",
    "lastName": "Stark",
    "driverLicenseNumber": "DL1000003",
    "vehicleYear": 1976,
    "vehicleModel": "Impala",
    "vehicleManufacturer": "Chevy",
    "vehicleName": "My Car",
    "streetAddress": "300 S RANKIN ST",
    "city": "RICHMOND",
    "state": "VA",
    "zip": "23224",
    "expirationDate": "2022-11-25T20:54:45.9774846",
    "premium": 80.95
  }
]
```


```plaintext
Retrieve a single policy of a member endpoint: api/policy/getpolicy (Request Type: GET)
```
Request Parameters:

| Attribute                | Type     | Required               | Description           |
|:-------------------------|:---------|:-----------------------|:----------------------|
| `policyId` | string(guid) | Yes | GUID assigned as Policy Id for a classic car insurance. |
| `dlNum` | string | Yes | Member Driver License number. |

Response body attributes:

| Attribute                | Type     | Description           |
|:-------------------------|:---------|:----------------------|
| `effectiveDate` | DateTime | Effective date of the insurance policy. |
| `firstName` | string | Member's first name. |
| `LastName` | string | Member's last name. |
| `driverLicenseNumber`| string | Member's alpha numeric driver license number. |
| `vehicleYear` | int | Vehicle year. |
| `vehicleModel` | string | Vehicle model. |
| `vehicleManufacturer`| string | Vehicle manufacturer. |
| `vehicleName` | string | Member provided name to identify their vehicles. |
| `streetAddress` | string | Member's street address. Must be valid US address |
| `city`| string | Member's city. Must be a valid US city |
| `state`| string | Member's state. Must be a valid US state |
| `zip`| string | Member's zip code. Must be a valid US zip |
| `expirationDate`| DateTime | Policy expiration date. |
| `premium`| double | Policy monthly cost. |

Example request:

```shell
curl -X 'GET' \
  'https://localhost:7018/api/policy/getpolicy?policyId=54215567-7C33-4537-A665-9E28456DC728&dlNum=DL1000003' \
  -H 'accept: */*'
```

Example response:

```
{
  "effectiveDate": "2022-06-24T20:54:45.977482",
  "firstName": "Tony",
  "lastName": "Stark",
  "driverLicenseNumber": "DL1000003",
  "vehicleYear": 1966,
  "vehicleModel": "Corolla",
  "vehicleManufacturer": "Toyota",
  "vehicleName": "My Car",
  "streetAddress": null,
  "city": null,
  "state": null,
  "zip": null,
  "expirationDate": "2022-11-25T20:54:45.9774821",
  "premium": 80.95
}
```

**If the State Regulations method is getting very complicated and a separate team is being started to own its requirements and code, what would you recommend to make that transition smoother?**
* I would start off by providing a detail documentation of the current logic and implementation of the State Regulation Method to the new team. A detailed knowledge transfer of how the State Regulation Method is being used in the current web api project would be beneficial to the new team.
* I would also provide the new team suggestions to convert the State Regulation method into a service that the rest api can consume. Using the State Regulation validation as a service would be beneficial in terms of extending the current business rules.
* Get information from the new team on how they would like to manage the State Regulation validation process and make appropriate changes based on their vision for the process.

**If you were to hand the code off to a new Engineering team for ownership. How should they think about productionizing it? (Monitoring, Logging, safe handling of PII, extending methods)**
* I would suggest deploying the app to cloud services such as Azure. 
* Setup monitoring and logging of the app using application insights would provide data regarding the overall health and performace of the app. I would also suggest using alerts in azure monitor for customized alerts based on the app's perfromance.
* The app stores data in a SQL Server database and it is essential to securely store PII data into the database. I would suggest using column level encryption to store PII data.
* The app is built using .net core framework which provides highly extensible options while keeping the project maintainable. I would suggest separating all of the business logics, logging and other services as separate functional units that can be registered as independent services and consumed by app.  

**Please describe how this code could be deployed and run in AWS or another cloud service provider. Which AWS services would be used? What infrastructure choices would you make? How would the code need to (if at all) change for this migration to the cloud?
* This app can be deployed to Azure App Service that can communicate with SQL Server database to perform CRUD operations. 
* I would choose an Azure App Service that allows auto scaling, multiple statging slots, traffic management and daily backups. The app service communicates with SQL Server database, so SQL database and SQL Server are the additional two resources required for the app. Additional publishing the app to Azure 
advantages such as centralized location for APIs, secure access to APIs, reporting on usage analytics, real time tracking etc.    
* For the current scenario of the app only the connection string needs to be updated to deploy it to Azure. The app should be able to communicate with the messaging services, since there is no integration that piece needs to be added to the code.