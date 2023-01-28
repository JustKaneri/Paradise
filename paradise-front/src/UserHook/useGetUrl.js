const getUrl = (file,element) => {

    if(file === null)
        return '';

    var fr = new FileReader();
    fr.onload = function () {
       element.current.src = fr.result;
    }

    fr.readAsDataURL(file);
}

export default getUrl;