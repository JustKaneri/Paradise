import React from 'react';
import getUrl from '../../../UserHook/useGetUrl';

const InputFileModalVideo = (props) => {

    const type = props.type;

    const files = props.files;
    const setFiles = props.setFiles;

    const data = props.data;
    const handler = props.handler;

    const onChangeFile= (event,type) => {
        event.stopPropagation();
        event.preventDefault();
        var file = event.target.files[0];

        let refObj = null;
       
        if(type == 'img'){
            handler(data => ({...data,poster:file}));
            setFiles({...files,pathPoster: props.reference.current.files[0]});
            refObj = props.poster;
        }            
        else{
            handler(data => ({...data, video:file}));
            setFiles({...files,pathVideo: props.reference.current.files[0]});
            refObj = props.video;
        }
        
        //getUrl(file, refObj);
    }

    return (
        <>
            <input ref={props.reference} id="file-input" 
                type='file'
                name="file"
                accept= {props.accept}
                multiple
                style={{display: 'none'}}
                onChange={(event) => onChangeFile(event,type)}
            />
        </>
    );
}

export default InputFileModalVideo;
