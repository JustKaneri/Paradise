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

> #### regestry 

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

> #### login 

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

> #### refresh_tokens

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

> #### revoked_tokens

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

### Comment

> #### comments

  URL https://[host-name]/api/v1/comment/comments?idVideo=[Parameters]

  Parameters
  idVideo - integer

  Result:
  ```json
	  	[
			  {
			    "id": 0,
			    "videoId": 0,
			    "content": "string",
			    "createdDate": "2023-01-06T11:24:02.444Z",
			    "user": {
			      "id": 0,
			      "name": "string",
			      "profile": {
			        "id": 0,
			        "idUser": 0,
			        "pathFon": "string",
			        "pathAvatar": "string"
			      }
			    }
			  }
			]
  ```

> #### new_comment

  URL https://[host-name]/api/v1/comment/new-comment

  Body:
  ```json
		{
		  "videoId": 0,
		  "content": "string",
		  "createdDate": "2023-01-06T11:36:52.494Z"
		}
  ```

  Result:
  ```json
  	{
		  "id": 0,
		  "videoId": 0,
		  "content": "string",
		  "createdDate": "2023-01-06T11:36:52.496Z",
		  "user": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  

### Profile

> #### get_profile

  URL https://[host-name]/api/v1/profile/user/[parametrs]/profile

  Parameters
  idUser = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "idUser": 0,
		  "pathFon": "string",
		  "pathAvatar": "string"
		}
  ```  

> #### upload_avatar

  URL https://[host-name]/api/v1/profile/user/profile/upload-avatar

  Body:
  Image file

  Result:
  ```json
  	{
		  "id": 0,
		  "idUser": 0,
		  "pathFon": "string",
		  "pathAvatar": "string"
		}
  ```  

> #### upload_fon

  URL https://[host-name]/api/v1/profile/user/profile/upload-fon

  Body:
  Image file

  Result:
  ```json
  	{
		  "id": 0,
		  "idUser": 0,
		  "pathFon": "string",
		  "pathAvatar": "string"
		}
  ```  

### Subscription

> #### get_subscriptions

  URL https://[host-name]/api/v1/subscription/subscriptions

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "subscriber": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### subscription_status

  URL https://[host-name]/api/v1/subscription/user/[Parameters_1]/subscription/status?idUser=[Parameters_2]

  Parameters
  1. idCanal = integer
  2. idUser = integer

  Result:
  True or false 

> #### subscrib

  URL https://[host-name]/api/v1/subscription/user/[Parameters]/subscribe

  Parameters
  idCanal = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "subscriber": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  

> #### unsubscrib

  URL https://[host-name]/api/v1/subscription/user/[Parameters]/unsubscribe

  Parameters
  idCanal = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "subscriber": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  


### Responce_Video

> #### info_responce

  URL https://[host-name]/api/v1/responce-video/video/[Parameters]/info-responce

  Parameters
  idVideo = integer

  Result:
  ```json
  	{
		  "countLike": 0,
		  "countDisLike": 0
		}
  ```  

> #### set_like

  URL https://[host-name]/api/v1/responce-video/like?idVideo=[Parameters]

  Parameters
  idVideo = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "userId": 0,
		  "videoId": 0,
		  "isLike": true,
		  "isDisLike": true,
		  "dateResponce": "2023-01-06T11:59:41.161Z"
		}
  ```  

> #### set_dislike

  URL https://[host-name]/api/v1/responce-video/dislike?idVideo=[Parameters]

  Parameters
  idVideo = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "userId": 0,
		  "videoId": 0,
		  "isLike": true,
		  "isDisLike": true,
		  "dateResponce": "2023-01-06T11:59:41.161Z"
		}
  ```  

> #### reset

  URL https://[host-name]/api/v1/responce-video/reset?idVideo=[Parameters]

  Parameters
  idVideo = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "userId": 0,
		  "videoId": 0,
		  "isLike": true,
		  "isDisLike": true,
		  "dateResponce": "2023-01-06T11:59:41.161Z"
		}
  ```  

### User_info

> #### info_user

  URL https://[host-name]/api/v1/user-information/user/[Parameters]/detailed-information

  Parameters
  idUser = integer

  Result:
  ```json
  	{
		  "countWatch": 0,
		  "countSubscrib": 0
		}
  ```  

### User_Role

> #### roles

  URL https://[host-name]/api/v1/user-role/roles

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string"
		  }
		]
  ```  

### Users

> #### get_all_users

  URL https://[host-name]/api/v1/users

  Result:
  ```json
  	[
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
		]
  ```  

> #### check_exist_login

  URL https://[host-name]/api/v1/users/user/[Parameters]/check-exist-login

  Parameters
  Login = string

  Result:
  True or false

> #### check_exist_login

  URL https://[host-name]/api/v1/users/user/[Parameters]/check-exist-name

  Parameters
  Name = string

  Result:
  True or false

### Video

> #### get_all_video

  URL https://[host-name]/api/v1/video/videos

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string",
		    "discript": "string",
		    "dateCreate": "2023-01-06T15:17:44.063Z",
		    "countWatch": 0,
		    "pathVideo": "string",
		    "pathPoster": "string",
		    "user": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### get_video_favorite

  URL https://[host-name]/api/v1/video/video/favorite

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string",
		    "discript": "string",
		    "dateCreate": "2023-01-06T15:17:44.063Z",
		    "countWatch": 0,
		    "pathVideo": "string",
		    "pathPoster": "string",
		    "user": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### get_video_by_current_user

  URL https://[host-name]/api/v1/video/user/[Paramaters]/video

  Parameters:
  idUser = integer

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string",
		    "discript": "string",
		    "dateCreate": "2023-01-06T15:17:44.063Z",
		    "countWatch": 0,
		    "pathVideo": "string",
		    "pathPoster": "string",
		    "user": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### get_video_by_page

  URL https://[host-name]/api/v1/video/video-page?page=[Parameters_1]&count=[Parameters_2]

  Parameters:
  1. page = integer
  2. count = integer

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string",
		    "discript": "string",
		    "dateCreate": "2023-01-06T15:17:44.063Z",
		    "countWatch": 0,
		    "pathVideo": "string",
		    "pathPoster": "string",
		    "user": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### get_video_by_page_search

  URL https://[host-name]/api/v1/video/video-page?page=[Parameters_1]&count=[Parameters_2]&search=[Parameters_3]

  Parameters:
  1. page = integer
  2. count = integer
  3. search = string

  Result:
  ```json
  	[
		  {
		    "id": 0,
		    "name": "string",
		    "discript": "string",
		    "dateCreate": "2023-01-06T15:17:44.063Z",
		    "countWatch": 0,
		    "pathVideo": "string",
		    "pathPoster": "string",
		    "user": {
		      "id": 0,
		      "name": "string",
		      "profile": {
		        "id": 0,
		        "idUser": 0,
		        "pathFon": "string",
		        "pathAvatar": "string"
		      }
		    }
		  }
		]
  ```  

> #### add_view

  URL https://[host-name]/v1/video/video/[Parameters]/add-views

  Parameters: idVideo = integer

  Result:
  ```json
  	{
		  "id": 0,
		  "name": "string",
		  "discript": "string",
		  "dateCreate": "2023-01-06T15:24:17.359Z",
		  "countWatch": 0,
		  "pathVideo": "string",
		  "pathPoster": "string",
		  "user": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  

> #### create_video(1/3)

  URL https://[host-name]/v1/video/video/create

  Body
  ```json
		{
		  "name": "string",
		  "discript": "string",
		  "dateCreate": "2023-01-06T15:25:41.703Z"
		}
  ```

  Result:
  ```json
  	{
		  "id": 0,
		  "name": "string",
		  "discript": "string",
		  "dateCreate": "2023-01-06T15:24:17.359Z",
		  "countWatch": 0,
		  "pathVideo": "string",
		  "pathPoster": "string",
		  "user": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  
  
> #### create_video(2/3)

  URL https://[host-name]/v1/video/video/[Parameters]/upload-video

  Parameters
  1. idVideo = integer

  Body
  1. Video file

  Result:
  ```json
  	{
		  "id": 0,
		  "name": "string",
		  "discript": "string",
		  "dateCreate": "2023-01-06T15:24:17.359Z",
		  "countWatch": 0,
		  "pathVideo": "string",
		  "pathPoster": "string",
		  "user": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  

> #### create_video(3/3)

  URL https://[host-name]/v1/video/video/[Parameters]/upload-poster

  Parameters
  1. idVideo = integer

  Body
  1. Image file

  Result:
  ```json
  	{
		  "id": 0,
		  "name": "string",
		  "discript": "string",
		  "dateCreate": "2023-01-06T15:24:17.359Z",
		  "countWatch": 0,
		  "pathVideo": "string",
		  "pathPoster": "string",
		  "user": {
		    "id": 0,
		    "name": "string",
		    "profile": {
		      "id": 0,
		      "idUser": 0,
		      "pathFon": "string",
		      "pathAvatar": "string"
		    }
		  }
		}
  ```  