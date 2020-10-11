window.bookieBookie = () => {
  function getPathFromLocation(location) {
    const params = new URLSearchParams(location.search);
    // Delete Urchin Tracking Module (UTM) parameters
    params.delete("utm_source");
    params.delete("utm_medium");
    params.delete("utm_campaign");
    params.delete("utm_term");
    params.delete("utm_content");

    params.delete("ck_subscriber_id");

    if (Array.from(params).length) {
      return `${location.origin}${location.pathname}?${params}`;
    } else {
      return `${location.origin}${location.pathname}`;
    }
  }

  function getTitle() {
    const metaTitle =
      document.querySelector('meta[property="twitter:title"]')?.content ??
      document.querySelector('meta[property="og:title"]')?.content;

    if (metaTitle) {
      return metaTitle;
    }

    return document.querySelector("title").textContent?.trim() ?? "";
  }

  function getImage() {
    const metaImage =
      document.querySelector('meta[name="twitter:image"]')?.content ??
      document.querySelector('meta[name="twitter:image:src"]')?.content ??
      document.querySelector('meta[property="og:image"]')?.content ??
      null;

    return metaImage;
  }

  function getTwitterHandle() {
    const metaImage =
      document.querySelector('meta[name="twitter:creator"]')?.content ?? null;

    return metaImage;
  }

  const title = encodeURIComponent(getTitle());
  const url = encodeURIComponent(getPathFromLocation(document.location));
  const imageSrc = encodeURIComponent(getImage());
  const twitterHandle = encodeURIComponent(getTwitterHandle());

  console.log(title);
  console.log(url);
  console.log(imageSrc);
  console.log(twitterHandle);

  var host = "https://theproblemsolver.azurewebsites.net";
  //var host = 'http://localhost:32662';
  document.body.appendChild(
    document.createElement("script")
  ).src = `${host}/Api/BookieBookie?url=${url}&title=${title}&image=${imageSrc}&by=${twitterHandle}`;

  document.body.appendChild(document.createElement("style")).textContent = `
/* The snackbar - position it at the bottom and in the middle of the screen */
#snackbar {
    visibility: hidden; /* Hidden by default. Visible on click */
    min-width: 250px; /* Set a default minimum width */
    margin-left: -125px; /* Divide value of min-width by 2 */
    background-color: #333; /* Black background color */
    color: #fff; /* White text color */
    text-align: center; /* Centered text */
    border-radius: 2px; /* Rounded borders */
    padding: 16px; /* Padding */
    position: fixed; /* Sit on top of the screen */
    z-index: 999; /* Add a z-index if needed */
    left: 50%; /* Center the snackbar */
    bottom: 30px; /* 30px from the bottom */
}

/* Show the snackbar when clicking on a button (class added with JavaScript) */
#snackbar.show {
    visibility: visible; /* Show the snackbar */

/* Add animation: Take 0.5 seconds to fade in and out the snackbar. 
However, delay the fade out process for 2.5 seconds */
    -webkit-animation: fadein 0.5s, fadeout 0.5s 2.5s;
    animation: fadein 0.5s, fadeout 0.5s 2.5s;
}

/* Animations to fade the snackbar in and out */
@-webkit-keyframes fadein {
    from {bottom: 0; opacity: 0;} 
    to {bottom: 30px; opacity: 1;}
}

@keyframes fadein {
    from {bottom: 0; opacity: 0;}
    to {bottom: 30px; opacity: 1;}
}

@-webkit-keyframes fadeout {
    from {bottom: 30px; opacity: 1;} 
    to {bottom: 0; opacity: 0;}
}

@keyframes fadeout {
    from {bottom: 30px; opacity: 1;}
    to {bottom: 0; opacity: 0;}
}
  `;

  var div = document.body.appendChild(document.createElement("div"));
  div.textContent = "Bookie bookie Saved";
  div.id = "snackbar";
  div.className = "show";
  setTimeout(function () {
    div.className = div.className.replace("show", "");
  }, 3000);
};

bookieBookie();
