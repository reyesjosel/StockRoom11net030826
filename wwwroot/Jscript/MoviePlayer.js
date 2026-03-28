export function playMovie(fileName, videoElement)
{   
    videoElement.src = `/Videos/${fileName}`;     
    videoElement.volume = .2;
    videoElement.play();
}

export function loadMovie(fileName, videoElement)
{    
    videoElement.src = `/Videos/${fileName}`;    
    videoElement.volume = .2;
    videoElement.load();
}



