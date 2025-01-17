# HostProduction - ASP.NET Core Test Task


## Database (MSSQL):
Database structure has been deployed using the Code First approach and Entity Framework Core. The content of the ProductionFacility and ProcessEquipmentType is automatically filled with data on db migration.

1. ProductionFacility: Id, Code, Name, StandardArea (content automatically filled).
![image](https://github.com/user-attachments/assets/705da47f-1305-4364-86e6-ba08fb309629)

2. ProcessEquipmentType: Id, Code, Name, Area (content automatically filled).
![image](https://github.com/user-attachments/assets/ebffb0d7-92be-4933-a642-ada6e25e7606)

3. EquipmentPlacementContract: Id, ProductionFacilityId, ProcessEquipmentTypeId, EquipmentQuantity (content created manually).
![image](https://github.com/user-attachments/assets/6167135d-44d2-4cda-951a-8b9aee8ff897)


## Functionality (ASP.NET Core):
Service has been implemented via ASP.NET Core Web API. 

Controller and RazorViews have been scaffolded using EquipmentPlacementContractVM:
1. Index (GET) - gets the list of type EquipmentPlacementContractVM and displays following fields: ProductionFacilityVM.Name, ProcessEquipmentTypeVM.Name, EquipmentQuantity.
![image](https://github.com/user-attachments/assets/fa7523c1-4bd0-4346-b045-565c3e59e64a)

2. CREATE (GET) - gets the create model of type EquipmentPlacementContractCreateVM with following input fields: SelectList ProductionFacilityVM, SelectList ProcessEquipmentTypeVM, input field EquipmentQuantity.
![image](https://github.com/user-attachments/assets/3f3aa97b-41b6-4890-bd4b-32a70b858093)

3. CREATE (POST) - creates the EquipmentPlacementContractCreateVM. The available area of production facility is validated and if there is no enough space an error is returned.
![image](https://github.com/user-attachments/assets/6813a864-91de-4813-be59-b2215de8af93)


##	Testing (Xunit):
Unit tests for the implemented controller have been implemented.

![image](https://github.com/user-attachments/assets/35c2763e-1c21-4c73-93cd-c37a83600d4f)


## Async Background Processor (EmailSender):
EmailSender service has been configured as async background processor via SendGrid.
![image](https://github.com/user-attachments/assets/e7e98fd2-a4d8-400e-be1e-74148e9560b1)


## Applied Design Patterns:
Following design patterns have been used during the implementation:
1. MVC - application follows the Model-View-Controller architectural pattern. AutoMapper is configured and used to map Models to ViewModels and other way.
2. Dependency Injection - three repositories have been configured for dependency injection
![image](https://github.com/user-attachments/assets/985cad51-aefc-4e23-bb8f-59a1e10f6ae6)

3. Repository - application follows the repository architectural pattern to make the code be more testable, clean and to follow the single responsibility principle.


## How to run:
1. Clone the repository:  
   ```bash
   git clone https://github.com/jedrulcia/HostProduction.git
   ```
2. Rename appsettings - template.json file to appsettings.json
3. Add required fields to the file (SendGrid configuration is not required, exception handles lack of it and the mail is just not sent, but make sure DB is configured)
   ```json
   {
    "ConnectionStrings": {
      "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HostProduction;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False",
      "SendGridConnectionString": ""
    },
    "SendFromEmail": "",
    "AllowedHosts": "*"
     }
   ```
4. Run database migration using Entity Framework:  
   ```bash
   add-migration InitialMigration
   ```
  
5. Update database using Entity Framework:  
   ```bash
   update-database
   ```
6. Start the application:  
   ```bash
   dotnet run
   ```
7. Login using preset user:
   ```
   Login: admin@localhost.com
   Password: Admin!2
   ```
