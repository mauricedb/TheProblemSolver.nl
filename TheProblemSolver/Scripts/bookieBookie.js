window.bookieBookie = () => {
    function getPathFromUrl(url) {
        return url.split(/[?#]/)[0];
    }

    const title = document.querySelector('title').textContent;
    const url = encodeURIComponent(getPathFromUrl(document.location.href));
    const image = document.querySelector('.progressiveMedia-image');
    let imageSrc = null;
    if (image) {
        imageSrc = image.src;
    }

    console.log(title);
    console.log(url);
    console.log(imageSrc);

    var host = 'https://theproblemsolver.azurewebsites.net';
    //var host = 'http://localhost:32662';
    document.body.appendChild(document.createElement('script')).src =
        `${host}/Api/BookieBookie?url=${url}&title=${title}&image=${imageSrc}`;
}

bookieBookie();