window.bookieBookie = () => {
    function getPathFromUrl(url) {
        return url.split(/[?#]/)[0];
    }

    const title = document.querySelector('title').textContent;
    const url = encodeURIComponent(getPathFromUrl(document.location.href));
	const image = document.querySelector('.progressiveMedia-image');
	let imageSrc = null;
	if (image){
		imageSrc = image.src
	}
	
    fetch(`https://api-ssl.bitly.com/v3/shorten?access_token=34b10af37f646d6d439967e20714315038621885&longUrl=${url}`)
        .then(rsp => rsp.json())
        .then(rsp => {
            if (rsp.status_code === 200) {
                console.log(title);
                console.log(rsp.data.url);
				console.log(imageSrc);
            } else {
                console.warn(rsp.status_code, rsp.status_txt);

                console.log(title);
				console.log(imageSrc);
            }
        })
		.catch(e => {
			console.warn(e);

			console.log(title);
			console.log(imageSrc);
		});
}

bookieBookie();