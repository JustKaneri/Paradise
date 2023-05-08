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


[host-name] = example localhost:7077


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
| get_comment |  Get list comments   | https://[host-name]/api/v1/comments?idVideo=[Parameters]   | integer - id video  | - | `[{ "id": 0, "videoId": 0, "content": "string", "createdDate": "2023-05-04T17:53:20.793Z","user": {"id": 0,"name": "string",      "profile": { "id": 0, "idUser": 0, "pathFon": "string",      "pathAvatar": "string" }}}]` |
| new_comment`(Auth)` |  Create new comment   | https://[host-name]/api/v1/comment |-| {"videoId": 0, "content": string"} | `{ "id": 0, "videoId": 0, "content": "string", "createdDate": "2023-05-04T17:53:20.793Z","user": {"id": 0,"name": "string",      "profile": { "id": 0, "idUser": 0, "pathFon": "string",      "pathAvatar": "string" }}}` |

### History controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_history(`Auth`) |  Get list history watch video   | https://[host-name]/api/v1/history  |- | - | `[{"id": 0,"name": "string", "discript": "string", "dateCreate": "2023-05-05T16:49:08.913Z",    "countWatch": 0, "pathVideo": "string",  "pathPoster": "string",  "user": { "id": 0, "name": "string", "profile": {"id": 0,       "idUser": 0, "pathFon": "string", "pathAvatar": "string"  } }}]` |
| create_history(`Auth`) |  Create new enity history watch video   | https://[host-name]/api/v1/history?idVideo={Parameters}  |int-idVideo | - | `{"id": 0,"dateWath": "2023-05-05T16:51:38.456Z", "userId": 0, "videoId": 0}` |


### Profile controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_profile |  Get profile current user  | https://[host-name]/api/v1/user/{Parameters}/profile |integer - idUser| - | `{ "id": 0, "idUser": 0,   "pathFon": "string",  "pathAvatar": string"}` |
| upload_avatar(`Auth`) |  Upload avatar for auth user | https://[host-name]/api/v1/user/profile/upload-avatar|-| multipart/form-data File, type image | `{ "id": 0, "idUser": 0,   "pathFon": "string",  "pathAvatar": string"}` |
| upload_fon(`Auth`)|  Upload fon for auth user   | https://[host-name]/api/v1/user/profile/upload-fon|-| multipart/form-data File, type image | `{ "id": 0, "idUser": 0,   "pathFon": "string",  "pathAvatar": string"}` |


### Responce video controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_count_responce |  Get count like and dislike for current video  | https://[host-name]/api/v1/responce-video/video/{Parameters}/count-responce |integer - idVideo| - | `{ "countLike": 0,  "countDisLike": 0}` |
| get_info_responce |  Get responce for auth user  | https://[host-name]/api/v1/responce-video/video/{Parameters}/info-responce | integer - idVideo| - | `{ "id": 0, "userId": 0,"videoId": 0,  "isLike": true, "isDisLike": true, "dateResponce": "2023-05-05T17:03:49.615Z"}` |
| set_like(`Auth`) |  Set like for current video  | https://[host-name]/api/v1/responce-video/like?idVideo={Parameters}| integer - idVideo| - | `{ "id": 0, "userId": 0,"videoId": 0,  "isLike": true, "isDisLike": true, "dateResponce": "2023-05-05T17:03:49.615Z"}` |
| set_dislike(`Auth`) |  Set dislike for current video  | https://[host-name]/api/v1/responce-video/dislike?idVideo={Parameters}| integer - idVideo| - | `{ "id": 0, "userId": 0,"videoId": 0,  "isLike": true, "isDisLike": true, "dateResponce": "2023-05-05T17:03:49.615Z"}` |
| reset_responce(`Auth`) |  Set dislike for current video  | https://[host-name]/api/v1/responce-video/reset?idVideo={Parameters}| integer - idVideo| - | `{ "id": 0, "userId": 0,"videoId": 0,  "isLike": true, "isDisLike": true, "dateResponce": "2023-05-05T17:03:49.615Z"}` |

### Subscription controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_subscriptions(`Auth`) | Get list subscription current user | https://[host-name]/api/v1/subscriptions |- | - | `[  { "id": 0, "subscriber": { "id": 0, "name": "string","profile": { "id": 0, "idUser": 0,"pathFon": "string","pathAvatar": "string" } }}]` |
| get_subscription_status(`Auth`) |  Get inforamation about subscription | https://[host-name]/api/v1/user/{Parameters}/subscription/status| integer - idUser | - | `Boolean`|
| subscrib(`Auth`) |  subscrib on current canal| https://[host-name]/api/v1/user/{Parameters}/subscribe| integer - idUser | - | `{"id": 0, "subscriber": { "id": 0, "name": "string","profile": { "id": 0, "idUser": 0, "pathFon": "string", "pathAvatar": "string"}}}` |
| unsubscrib(`Auth`) |  Unsubscrib on current canal| https://[host-name]/api/v1/user/{Parameters}/unsubscribe| integer - idUser | - | `{"id": 0, "subscriber": { "id": 0,"name":"string","profile":{ "id": 0, "idUser": 0, "pathFon": "string", "pathAvatar": "string"}}}` |

### User info controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_user_info |  Get total count watch and total subscriber | https://[host-name]/api/v1/user/{Parameters}/detailed-information | integer - idUser| - | `{"countWatch": 0,  "countSubscrib": 0}` |


### User role controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_roles(`Auth`)(`Admin`) |  Get list roles | https://[host-name]/api/v1/roles | - | - | `[{"id": 0,    "name": "string"}]` |

### User controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_users(`Auth`)(`Admin`) |  Get list users | https://[host-name]/api/v1/users | - | - | `[{"id": 0,"name": "string",   "profile": {"id": 0,"idUser": 0,"pathFon": "string",   "pathAvatar": "string"}}]` |
| get_user  |  Get selection user | https://[host-name]/api/v1/users/{Parameters} | integer - IdUser | - | `{"id": 0,"name": "string",   "profile": {"id": 0,"idUser": 0,"pathFon": "string",   "pathAvatar": "string"}}` |
| get_user(`Auth`)  |  Get auth user by token| https://[host-name]/api/v1/users/auth | integer - IdUser | - | `{"id": 0,"name": "string",   "profile": {"id": 0,"idUser": 0,"pathFon": "string",   "pathAvatar": "string"}}` |
| check_login |  Checked is exist login | https://[host-name]/api/v1/users/{Parameters}/check-exist-login | string - Login | - | `Boolean` |
| check_name|  Checked is exist name| https://[host-name]/api/v1/users/{Parameters}/check-exist-name | string - Login | - | `Boolean` |

### Video controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| get_video |  Get list video | https://[host-name]/api/v1/videos | - | - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}]` |
| get_video |  Get current video | https://[host-name]7/api/v1/video/{Parameters} | integer - IdVideo | - | `{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}` |
| get_favorite_video |  Get favorite video auth user | https://[host-name]/api/v1/video/favorite | - | - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}]` |
| get_user_video |  Get list video by user | https://[host-name]/api/v1/user/{Parameters}/video | integer - idUser | - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}]` |
| get_video |  Get list video by page| https://[host-name]/api/v1/video-page?page={Parameters}&count={Parameters} | integer - page, integer - count | - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}]` |
| get_video |  Get list video by page with search| https://[host-name]/api/v1/video-page-search?page={Parameters}&count={Parameters}&search={Parameters}| integer - page, integer - count, sting - search| - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}]` |
| create_view| Increase count view video| https://[host-name]/api/v1/video/{Parameters}/add-views| integer - idVideo| - | `[{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}` |


### Video creator controller

| Name | Discript| Url | Parameters | Body request |Responce |
| :---         |     :---:      | :---         |     :---:      |          ---: |          ---: |
| create_video(`Auth`) | Create new video | https://[host-name]/api/v1/video/videos | 1) multipart/form-data File, type video, 2)multipart/form-data File, type image | {"name": "string","discript": "string"} | `{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}` |
| upload_video(`Auth`) | replace exist video| https://[host-name]/api/v1/video/{Parameters}/upload-video | integer - idVideo, multipart/form-data File, type video |  - | `{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}` |
| upload_poster(`Auth`) | replace poster for video| https://[host-name]/api/v1/video/{Parameters}/upload-poster | integer - idVideo, multipart/form-data File - type image |  - | `{"id": 0,"name": "string","discript": "string",  "dateCreate": "2023-05-08T11:32:00.711Z","countWatch": 0,   "pathVideo": "string","pathPoster": "string","user": {"id": 0,    "name": "string","profile": {"id": 0,"idUser": 0,"pathFon": "string","pathAvatar": "string"}}}` |
