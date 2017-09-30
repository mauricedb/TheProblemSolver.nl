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

    document.body.appendChild(document.createElement('script')).src =
        `http://localhost:32662/Api/BookieBookie?url=${url}&title=${title}&image=${imageSrc}`;
}

bookieBookie();