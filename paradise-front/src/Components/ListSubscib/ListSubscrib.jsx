import React from 'react';
import './listSubscrib.css'
import SubscribItem from './SubscibItem/SubscribItem';

const ListSubscrib = () => {

    const subscribs = [
  	  {
  	    "id": 1,
  	    "subscriber": {
  	      "id": 2,
  	      "name": "Name1",
  	      "profile": {
  	        "id": 0,
  	        "idUser": 2,
  	        "pathFon": "string",
  	        "pathAvatar": "https://pixelbox.ru/wp-content/uploads/2021/05/ava-vk-animal-91.jpg"
  	      }
  	    }
  	  },
        {
            "id": 2,
            "subscriber": {
              "id": 3,
              "name": "Name1",
              "profile": {
                "id": 0,
                "idUser": 3,
                "pathFon": "string",
                "pathAvatar": "https://shapka-youtube.ru/wp-content/uploads/2020/08/man-silhouette.jpg"
              }
            }
          }
      ,{
        "id": 3,
        "subscriber": {
          "id": 4,
          "name": "Name1",
          "profile": {
            "id": 0,
            "idUser": 4,
            "pathFon": "string",
            "pathAvatar": "https://instaok.ru/images/wp-content/uploads/2021/01/image201-12-1084x720.jpg"
          }
        }
      }
      ,
      {
        "id": 4,
        "subscriber": {
          "id": 5,
          "name": "Name1",
          "profile": {
            "id": 0,
            "idUser": 5,
            "pathFon": "string",
            "pathAvatar": "https://pixelbox.ru/wp-content/uploads/2022/08/avatars-viber-pixelbox.ru-31.jpg"
          }
        }
      }
  	]

    return (
        <div className='list-sub'>
            {subscribs.map((sub)=>
                <SubscribItem
                    key={sub.id}
                    subscrib = {sub}
                ></SubscribItem>
            )}
        </div>
    );
}

export default ListSubscrib;
