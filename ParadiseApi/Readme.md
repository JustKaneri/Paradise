# Paradise api (Backend)

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

(Auth) = Authorization required


### Api controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_status  |  Get status Api   | https://[host-name]/api/status    | -    | - | `string` |
| get_version  |  Get list all versions  | https://[host-name]/api/versuin   | -    | - | `[ string]` |


### Authentication controller

| Name | Discript| Url | Parameters | Body request |Responce|
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| regestry  |  Regestry new user |https://[host-name]/api/v1/authentication/regestry   | -    | { "name": "string", "login": "string", "password": "string", "confirmPassword": "string"} | `{ "token": "string", "refreshToken": "string", "error": "string" }` |
| Login |  Authentication  user |https://[host-name]/api/v1/authentication/login   | -    | {"name": "string","login": "string", "password": "string"	} | `{ "token": "string", "refreshToken": "string", "error": "string" }` |
| Refresh tokens |update authentication tokens |https://[host-name]/api/v1/authentication/refresh-tokens   | -    | {"token": "string", "refreshToken": "string"	} | `{ "token": "string", "refreshToken": "string", "error": "string" }` |
| Revoked tokens |update authentication tokens |https://[host-name]/api/v1/authentication/revoked-token   | -    | {"token": "string", "refreshToken": "string"	} | `{ "token": "string", "refreshToken": "string", "error": "string" }` |

### Comment controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_comment |  Get list comments   | https://[host-name]/api/v1/comment/comments?idVideo=[Parameters]   | integer - id video  | - | `[{ "id": 0, "videoId": 0, "content": "string", "createdDate": "2023-05-04T17:53:20.793Z","user": {"id": 0,"name": "string",      "profile": { "id": 0, "idUser": 0, "pathFon": "string",      "pathAvatar": "string" }}}]` |
| new_comment`(Auth)` |  Create new comment   | https://[host-name]/api/v1/comment/new-comment   |-| {"videoId": 0, "content": string"} | `{ "id": 0, "videoId": 0, "content": "string", "createdDate": "2023-05-04T17:53:20.793Z","user": {"id": 0,"name": "string",      "profile": { "id": 0, "idUser": 0, "pathFon": "string",      "pathAvatar": "string" }}}` |
