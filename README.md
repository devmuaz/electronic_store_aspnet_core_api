# ASP.NET Core Web Api
A well structured api built using the .Net core frameworks with some of the most popular design patterns.

## Packages
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.AspNetCore.Authentication.JwtBearer
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.IdentityModel.Tokens
- Swashbuckle.AspNetCore
- System.IdentityModel.Tokens.Jwt


## Migrations
- First, make sure you have the EF (Entity Framework) tools installed by typing the following command <br>
  `dotnet tool install --global dotnet-ef`

- Now, to migrate do the follwoing commands <br>
  `dotnet ef migrations add InitialMigrations` <br>
  `dotnet ef database update`


## Endpoints
### Products:
- [GET] api/v1/products/all
- [GET] api/v1/products/get (QUERY)
- [POST] api/v1/products/create (FORM DATA)
- [POST] api/v1/products/update (QUERY)
- [DELETE] api/v1/products/delete (QUERY)

### Categories:
- [GET] api/v1/categories/all
- [GET] api/v1/categories/get (QUERY)
- [POST] api/v1/categorie/create (QUERY)
- [POST] api/v1/categories/update (QUERY)
- [DELETE] api/v1/categories/delete (QUERY)

### Users:
- [GET] api/v1/users/{username}

### Auth:
- [GET] api/v1/auth/me (HEADER AUTHORIZATION) (Bearer Token)
- [POST] api/v1/auth/signin (FORM DATA)
- [POST] api/v1/auth/signup (FORM DATA)


## Storage & wwwroot
### Products (each product contains images up to 5) and stored in the path:
- uploads/products

### Users (user avatar) stored in the path:
- uploads/avatars

## API Testing (Swagger)
The API was integrated with Swagger so it can be easily tested
- https://localhost:5001/swagger/index.html

## For More
- [Facebook](https://www.facebook.com/AbdulMuaz.Aqeel.SSP "AbdulMuaz Aqeel")
- [Instagram](https://www.instagram.com/abdulmuaz_ssp "AbdulMuaz Aqeel")
