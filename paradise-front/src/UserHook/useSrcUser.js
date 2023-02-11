import images from "../Other/DictonaryImage";


export default class getSrcUser{

  static Avatar (user){

    let src = images.profile;

    if(user.profile != null)
      if(user.profile.pathAvatar != null)
        src = user.profile.pathAvatar;

    return src;
  }

  static Fon (user) {

      let src = images.profile;

      if(user.profile != null)
        if(user.profile.pathFon != null)
          src = user.profile.pathFon;

      return src;
  }

}
