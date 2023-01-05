# Paradise api

## Description: 

> Api for the Paradise video Hosting site


## Dependencies:

> AutoMapper Version="12.0.0"


> AutoMapper.Extensions.Microsoft.DependencyInjection Version="12.0.0"


> Microsoft.EntityFrameworkCore Version="7.0.0"


> Microsoft.EntityFrameworkCore.SqlServer Version="7.0.0"


> Microsoft.EntityFrameworkCore.Tools Version="7.0.0"


> Microsoft.AspNetCore.Authentication.JwtBearer Version="6.0.12"



## End Points

### Authentication

> #### Regestry 

  URL https://[host-name]/api/v1/authentication/regestry

  Body:
  ```json
	{
	  "name": "string",
	  "login": "string",
	  "password": "string"
	}
  ```

  Result:
  ```json
  	{
	  "id": 0,
	  "name": "string",
	  "profile": {
	    "id": 0,
	    "idUser": 0,
	    "pathFon": "string",
	    "pathAvatar": "string"
 	  }
	}
  ```

> #### Login 

  URL https://[host-name]/api/v1/authentication/login

  Body:
  ```json
	{
	  "login": "string",
	  "password": "string"
	}
  ```
  
  Result:
  ```json
  	{
	  "token": "string",
	  "refreshToken": "string",
	  "error": "string"
	}
  ```

> #### Refresh-tokens

  URL https://[host-name]/api/v1/authentication/refresh-token

  Body:
  ```json
	{
	  "token": "string",
	  "refreshToken": "string"
	}
  ```

  Result:
  ```json
  	{
	  "token": "string",
	  "refreshToken": "string",
	  "error": "string"
	}
  ```  

> #### Revoked-tokens

  URL https://[host-name]/api/v1/authentication/refresh-token

  Body:
  ```json
	{
	  "token": "string",
	  "refreshToken": "string"
	}
  ```

  Result:
  ```json
  	{
	  "token": "string",
	  "refreshToken": "string",
	  "error": "string"
	}
  ```  
