function createAlertWindow(Title, Content, Submit, Cancel) {
    $.confirm({
        title: Title,
        content: Content,
        submit: Submit,
        cancel: Cancel,
        style: {
            bg: {},
            wrap: {
                width: "250px"
            },


            button: {},
            buttonSubmit: {},
            buttonCancel: {},
            content: {
                padding: "20px 10px"
            }

        }
    }, function () {
        alert("submit");
        $(".msg-bg").fadeOut("fast");
    }, function () {
        $(".msg-bg").fadeOut("fast");
    })
}
//createAlertWindow("Test Title", "Test Content", "Bestätigen", "Abbrechen");