import { useState, useEffect } from 'react';

const ApiPOST = async (method, url, params, callbackSuccess, callbackFailed) => {
    var formData = new FormData();


    if (params != null) {
        for (var key in params) {
            if (params.hasOwnProperty(key)) {
                formData.append(key, params[key]);
            }
        }
    }

    try{
        fetch(url, {
            method: method === null ? 'POST' : method,
            body: formData,
            headers: {
                'Accept':'application/json',
                //'Content-Type': 'multipart/form-data'
              }
        })
        .then((response) => response.json())
        .then((json) => callbackSuccess(json))
        .catch((error) => callbackFailed(error));
    }
    catch (error){
        console.log('error');
    }  

};

const ApiGET = async (url, callbackSuccess, callbackFailed) => {
    try{
        fetch(url, {
            method: 'GET',
            headers: {
                'Accept':'application/json',
                //'Content-Type': 'multipart/form-data'
                }
        })
        .then((response) => response.json())
        .then((json) => callbackSuccess(json))
        .catch((error) => callbackFailed(error));
    }
    catch (error){

    }


};

const GetSection = (sections, orderid) => {
    if (sections === null && sections.obj.length === 0)
    {
        return null;
    }
    for (var i = 0; i < sections.obj.length; i++){
        if (sections.obj[i].OrderId === orderid){

            return sections.obj[i];
        }
    }
    return null;
}

const getWindowDimensions = () => {
    const { innerWidth: width, innerHeight: height } = window;
    return {
        width,
        height
    };
}

const UseWindowDimensions = () => {
    const [windowDimensions, setWindowDimensions] = useState(getWindowDimensions());

    useEffect(() => {
        function handleResize() {
            setWindowDimensions(getWindowDimensions());
        }

        window.addEventListener('resize', handleResize);
        return () => window.removeEventListener('resize', handleResize);
    }, []);

    return windowDimensions;
}

export {
    ApiPOST,
    ApiGET,
    GetSection,
    UseWindowDimensions
}