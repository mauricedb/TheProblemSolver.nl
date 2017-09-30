window.bookieBookie = () => {
    function getPathFromUrl(url) {
        return url.split(/[?#]/)[0];
    }

    const title = document.querySelector('title').textContent;
    const url = encodeURIComponent(getPathFromUrl(document.location.href));

    fetch(`https://api-ssl.bitly.com/v3/shorten?access_token=34b10af37f646d6d439967e20714315038621885&longUrl=${url}`)
        .then(rsp => rsp.json())
        .then(rsp => {
            if (rsp.status_code === 200) {
                console.log(title);
                console.log(rsp.data.url);
            } else {
                console.log(rsp.status_code, rsp.status_txt);
            }
        });
}

bookieBookie();