//ToDo: Check If Permission is granted

//Send PushNotification
function sendNotification(Title, Content, Icon, Image, Tag, Badge) {
    const content = Content;
    const title = Title;
    const options = {
        body: content,
        icon: Icon,
        vibrate: [200, 100, 200],
        tag: Tag,
        image: Image,
        badge: Badge,
        actions: [
            { action: "Detail", title: "View", icon: "https://via.placeholder.com/128/ff0000" },
            { action: "Test", title: "Test" }
        ]
    };
    navigator.serviceWorker.ready.then(function (serviceWorker) {
        serviceWorker.showNotification(title, options);
    });
}

sendNotification("Zero - Wilkommen", "Willkommen Benutzer bei Zero!", "/images/jason-leung-HM6TMmevbZQ-unsplash.jpg", "/images/jason-leung-HM6TMmevbZQ-unsplash.jpg", "new Login", "https://spyna.it/icons/android-icon-192x192.png");