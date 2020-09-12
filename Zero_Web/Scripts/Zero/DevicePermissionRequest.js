function requestAllPermissions() {
    requestPushNotificationPermission();
    requestMicroPermission();
    requestCameraPermission();
    requestLocationPermission();
}

requestAllPermissions();

function requestPushNotificationPermission() {
    Notification.requestPermission(function (result) { /* ... */ });
}

function requestMicroPermission() {

    const player = document.getElementById('player');
    const handleSuccess = function (stream) { };

    navigator.mediaDevices.getUserMedia({ audio: true, video: false })
        .then(handleSuccess);
}

function requestCameraPermission() {
    if ('mediaDevices' in navigator && 'getUserMedia' in navigator.mediaDevices) {
        console.log("Camera Device detected.");
        navigator.mediaDevices.getUserMedia({ video: true });
    } else {
        console.log("No Camera Device detected.");
    }
}

function requestLocationPermission() {
    navigator.permissions.query({ name: 'geolocation' }).then(function (result) {
        if (result.state == 'granted') {
            //
        } else if (result.state == 'prompt') {
            navigator.geolocation.getCurrentPosition(function (position) {

            });
        } else if (result.state == 'denied') {
            //
        }
        result.onchange = function () {
            console.log(result.state);
        }
    });
}
