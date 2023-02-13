<img src="https://user-images.githubusercontent.com/53062219/218428707-76f92e29-cb77-4469-aab2-ed1b38a379b0.png" alt="logo" title="logo" align="right" height="60" />

# YouthCare
> Software System for automation of health control in youth sports.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Architecture](#architecture)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Contact](#contact)
* [License](#license)

## General Information
In terms of the university course work, there was developed a system that consists of back-end and front-end services.

System provides a friendly UI along with REST API requests to work with the data about youth sports, sportsmen health, collecting statistics etc.

It supports localization for two languages: 
 - Ukrainian
 - English

## Technologies Used
- ASP.NET Core 3.1
- Angular 11
- C#
- TypeScript
- MSSQL
- ASP.NET Identity
- Swagger

## Architecture
Back-end project has N-Layered Architecture that consists of 5 layers:
- YouthCare - Presentation Layer
- BLL - Business Logic Layer
- DAL - Data Access Layer
- CIL - Core Infrastructure Layer
- DIL - Dependency Injection Layer

## Features
List the ready features here:
- Authorization & Authentication with ASP.Identity and JWT token
- Admin/Sportsman/Doctor roles
- User Account Functionality
- Manage user accounts as an *admin*
- Create and upload a data backup as an *admin*
- Take health tests as a *sportsman*
- Receive analysis results in different formats as a *sportsman*
- Obtain admission to competitions as a *sportsman*
- View the results of analyzes of athletes of the same section as a *doctor*
- Chat system as a *sportsman* and as a *doctor*
- Manage personal notes as a *sportsman* and as a *doctor*

## Screenshots
<img src="https://user-images.githubusercontent.com/53062219/218435903-a66c566e-c5c8-47df-bb39-23be2757286c.png" height="450" />
<img src="https://user-images.githubusercontent.com/53062219/218435766-f5e6946e-baad-42c7-a34f-d9514cdd50fe.png" height="450" />
<img src="https://user-images.githubusercontent.com/53062219/218436176-2f800a10-f855-4c14-8689-2ad97fe5dcd3.png" height="450" />
<img src="https://user-images.githubusercontent.com/53062219/218436188-7fbec988-fb74-4fa4-a52e-24913088edd4.png" height="450" />

## Setup
You need to download this repository and run it using Visual Studio 2019 or newer version or any other IDE that is suitable for you.
> There is no need to run `npm install` if you run the whole project with an IDE.

## Usage
After successful build via Visual Studio (or any other IDE compatible with .NET), you can access a back-end service as `https://localhost:yourport/swagger/index.html`
and a front-end service as `https://localhost:yourport`.

## Project Status
Project is: _no longer being worked on_.

## Contact
Created by [@dench327](https://linkedin.com/in/https://www.linkedin.com/in/denis-semko-551b91191) - feel free to contact me!

© 2021

## License
> You can check out the full license [here](https://github.com/DenisSemko/SecondChance/blob/master/LICENSE.md)
This project is licensed under the terms of the MIT license.
