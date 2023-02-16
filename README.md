<p align="center">
  <h3 align="center">Ship CRUD Backend</h3>
</p>

<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#run-locally">Locally</a></li>
        <li><a href="#docker">Docker</a></li>
      </ul>
    </li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>

<!-- ABOUT THE PROJECT -->
## About The Project
This is the backend of the Ship Management Project, which includes all CRUD operations. 

### Built With

The website is built using the following technologies: 
* [ASP.NET](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)

<!-- GETTING STARTED -->
## Getting Started

To make this project work locally, please follow the instructions below. Also, this project supports Docker, so if you desire to use it, please follow the instructions in the Docker section. 

Before starting, please clone the repository: 
   ```sh
   git clone https://github.com/kevinvpereira/ship-management-backend.git
   ```
Also, please follow the instructions for the frontend project, otherwise, it won't work as expected: https://github.com/kevinvpereira/ship-management-front
   
### Run locally

If you are using Visual Studio, it should automatically download the correct version and allow you to run it. Once done, you can select the API project as the Startup project and then hit the run button. 

If you are not using Visual Studio, please follow the instructions:

#### Pre-requisites

* Install Dotnet SDK 6.0
https://dotnet.microsoft.com/en-us/download

#### Instructions
1. Build the project, in the project folder
   ```sh
   dotnet build
   ```
2. Run the command, in the ShipManagement.API folder
   ```sh
   dotnet run
   ```
3. If everything worked as expected, you can test the application at https://localhost:44337/swagger/index.html If it is running at a different port, please update the frontend API URL under environment.development to reflect it. 

### Docker

1. Create the image (run this command on the solution folder)
   ```sh
   docker build -f ShipManagement.API/Dockerfile -t ship-management-backend:dev .
   ```
2. Create the container
   ```sh
   docker run --name ship-management-backend-container -d -p 8080:80 ship-management-backend:dev
   ``` 
3. If everything worked as expected, you can test the application at http://localhost:8080/swagger/index.html

<!-- CONTACT -->
## Contact

Kevin Pereira -[@kevinvpereira](https://www.linkedin.com/in/kevinvpereira/)
