function requestCookiePermission(Message) {
    var script = document.createElement('script');
    script.src = "//cdnjs.cloudflare.com/ajax/libs/cookieconsent2/1.0.9/cookieconsent.min.js";
    document.head.appendChild(script);

    window.cookieconsent_options = { "message": Message, "dismiss": "Zustimmen", "learnMore": "Mehr Infos", "link": "http://de.webnode.com/datenschutzerklaerung/", "theme": "dark-bottom" };
}

requestCookiePermission("Diese Webseite nutzt Cookies, um bestmögliche Funktionalität bieten zu können.");