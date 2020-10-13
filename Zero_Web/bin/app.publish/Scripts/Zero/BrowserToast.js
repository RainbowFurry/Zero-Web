function successToast() {
    notification("Success Title", "Success Message", "success");
}

function infoToast() {
    notification("Info Title", "Info Message", "info");
}

function errorToast() {
    notification("Error Title", "Error Message", "error");
}

function warningToast() {
    notification("Warning Title", "Warning Message", "warning");
}

successToast();
infoToast();
errorToast();
warningToast();