import React from 'react';
import CommentItem from './CommentItem/CommentItem';
import styles from './listComments.module.css'

const ListComments = () => {

    const comments = [
        {
          "id": 1,
          "videoId": 0,
          "content": "Lalala",
          "createdDate": "2023-01-06T11:24:02.444Z",
          "user": {
            "id": 0,
            "name": "User 1",
            "profile": {
              "id": 0,
              "idUser": 0,
              "pathFon": "string",
              "pathAvatar": "https://pixelbox.ru/wp-content/uploads/2021/09/avatar-boys-vk-96.jpg"
            }
          }
        },
        {
            "id": 2,
            "videoId": 0,
            "content": "Lol",
            "createdDate": "2023-01-06T11:24:02.444Z",
            "user": {
              "id": 0,
              "name": "User 2",
              "profile": {
                "id": 0,
                "idUser": 0,
                "pathFon": "string",
                "pathAvatar": "https://i.pinimg.com/originals/13/8c/29/138c29e7f97e4072f52c4f91ee80f561.jpg"
              }
            }
          }
          ,
          {
              "id": 3,
              "videoId": 0,
              "content": "Lol dadawadadadw awdawd dawd aw",
              "createdDate": "2023-01-06T11:24:02.444Z",
              "user": {
                "id": 0,
                "name": "User 3",
                "profile": {
                  "id": 0,
                  "idUser": 0,
                  "pathFon": "string",
                  "pathAvatar": "https://pixelbox.ru/wp-content/uploads/2021/09/avatar-anime-boys-vkontakt-pixelbox.ru-84.jpg"
                }
              }
            }
    ];
    
    return (
        <div className={styles.box}>
            {comments.map(value => 
                <CommentItem 
                    key={value.id} 
                    comment = {value}
                />
            )}
        </div>
    );
}

export default ListComments;
