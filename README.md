# BlogFest - Simple forum website
> A simple forum created using pure ddd, cqrs, aop approaches.

## General info
The main goal of this project is to use pure domain models without strict binding to the orm framework.

Orm frameworks often do not have flexible enough functionality for modeling expressive business rules, 
so it is necessary to adapt domain objects to the capabilities of the orm system.

To achieve this goal, we used domain-specific events to which repositories subscribe and react to changes by modifying the database state.

## Technologies Used
* Asp .Net Core
* MS SQL
* Dapper
* Entity FrameWork Core

## Setup
This project uses sendgrid for mailing in sinup, password recovery scenarios.

If you want to check authentication scenario then pass sengrid api key into appsettings.json:

```
  "EmailSettings": {
    "ApiKey": "",
    "SenderEmail": "",
    "SenderName": "Blog Fest"
  }
```
Otherwise you can use the following credentials:
*login: admin
password: jVKhpWN2rRkb
*login: marty
password: jVKhpWN2rRkb
