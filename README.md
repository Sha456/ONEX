# ONEX

In addition to what was asked I have implemented the CQRS design pattern. (Command Query Responsibility Segregation).

I was not able to add Docker support as there's a bug in Docker that crashes on AMD processor.

Steps to execute the application

1. Download and run the application. Swagger UI will be loaded.

you will need to first create an asset, thereafter you could execute any command at your preference. 

/Asset/createasset

{
  "assetName": "Hard Drive",
  "departmentId": 2,
  "countryOfDepartment": "ALB",
  "purchaseDate": "2021-04-08T12:04:48.451Z",
  "eMailAdressOfDepartment": "sha@sha.com",
  "broken": true
}

