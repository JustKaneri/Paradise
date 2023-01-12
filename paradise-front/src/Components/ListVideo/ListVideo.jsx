import React from 'react';
import VideoItem from './VideoItem/VideoItem';
import './listVideo.css'

const ListVideo = () => {

    const videoArray = [
  	  {
  	    "id": 1,
  	    "name": "Video",
  	    "discript": "string",
  	    "dateCreate": "2023-01-06T15:17:44.063Z",
  	    "countWatch": 12,
  	    "pathVideo": "string",
  	    "pathPoster": "https://kartinkin.net/pics/uploads/posts/2022-07/1658484003_18-kartinkin-net-p-priroda-khakasii-priroda-krasivo-foto-18.jpg",
  	    "user": {
  	      "id": 0,
  	      "name": "User1",
  	      "profile": {
  	        "id": 2,
  	        "idUser": 2,
  	        "pathFon": "string",
  	        "pathAvatar": "https://pixelbox.ru/wp-content/uploads/2022/06/risovanie-avatars-for-girls-pixelbox.ru-78.jpg"
  	      }
  	    }
  	  },
      {
            "id": 2,
            "name": "Video",
            "discript": "string",
            "dateCreate": "2023-01-06T15:17:44.063Z",
            "countWatch": 12,
            "pathVideo": "string",
            "pathPoster": "https://vsluh.ru/upload/archive/novosti/transport/7f3/altay-baykal-khakasiya-gde-i-pochem-otdokhnut-v-rossii-etim-letom_344095/images/d6a0082031d89592308d3868f23f1895.jpg",
            "user": {
              "id": 3,
              "name": "User2",
              "profile": {
                "id": 3,
                "idUser": 0,
                "pathFon": "string",
                "pathAvatar": "https://вести35.рф/images/2018/11/22/9b846a76bf9847c29f263fc4e9f23d43.jpg"
              }
            }
      },
      {
            "id": 3,
            "name": "Videodawdaw",
            "discript": "string",
            "dateCreate": "2023-01-06T15:17:44.063Z",
            "countWatch": 12,
            "pathVideo": "string",
            "pathPoster": "https://w-dog.ru/wallpapers/5/5/533567594584480/eda-sladkoe-tort-tortik-pirozhnoe-krem-vkusno.jpg",
            "user": {
              "id": 4,
              "name": "User8",
              "profile": {
                "id": 4,
                "idUser": 4,
                "pathFon": "string",
                "pathAvatar": "https://вести35.рф/images/2018/11/22/9b846a76bf9847c29f263fc4e9f23d43.jpg"
              }
            }
      },
      {
              "id": 5,
              "name": "Videawdawo",
              "discript": "string",
              "dateCreate": "2023-01-06T15:17:44.063Z",
              "countWatch": 12,
              "pathVideo": "string",
              "pathPoster": "https://vsluh.ru/upload/archive/novosti/transport/7f3/altay-baykal-khakasiya-gde-i-pochem-otdokhnut-v-rossii-etim-letom_344095/images/d6a0082031d89592308d3868f23f1895.jpg",
              "user": {
                "id": 6,
                "name": "User6",
                "profile": {
                  "id": 6,
                  "idUser": 6,
                  "pathFon": "string",
                  "pathAvatar": "https://вести35.рф/images/2018/11/22/9b846a76bf9847c29f263fc4e9f23d43.jpg"
                }
              }
      },
  	];

    return (
        <div className='list-video'>
            {videoArray.map((value)=>
                <VideoItem
                     videoItem = {value}
                ></VideoItem>)
            }
        </div>
    );
}

export default ListVideo;
