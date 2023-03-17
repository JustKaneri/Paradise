export const getShortDate = (date) =>{
    return new Date(date).toLocaleDateString(); 
}

export const getTime = (date) =>{
    return new Date(date).toLocaleTimeString('en-GB'); 
}