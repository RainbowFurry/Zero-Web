
; (function (jQuery) {

    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (args[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            }
            else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined) {
                        var reg = new RegExp("({)" + i + "(})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }
        return result;
    };


    var _body = jQuery(document.body);

    var tooltip = {
        "size": {
            "width": 0,
            "height": 0
        },

        "element": null,

        "init": function (setting) {
            var defSetting = {
                position: "absolute",
                top: "0",
                left: "0",
                display: "none",
                backgroundColor: "#3A3A3A",
                padding: "5px 10px",
                borderRadius: "2px",
                color: "#fff",
                fontSize: "13px",
                opacity: ".8",
                fontFamily: "Roboto Condensed",
                zIndex: "99999",
                maxWidth: "480px",
                wordBreak: "break-all"
            };
            if (jQuery.isPlainObject(setting) && !$.isEmptyObject(setting)) {
                jQuery.extend(true, defSetting, setting);
            }
            if (tooltip.element === null) {
                tooltip.element = jQuery("<div class='tooltip'></div>").css(jQuery.extend(true, {}, defSetting));
                _body.append(tooltip.element);


                _body.off("mouseenter.tooltip", "[data-tooltip]").on("mouseenter.tooltip", "[data-tooltip]", tooltip.show);
                _body.off("mouseleave.tooltip mousedown.tooltip", "[data-tooltip]").on("mouseleave.tooltip mousedown.tooltip", "[data-tooltip]", tooltip.hide);
            }
        },

        "position": function (x, y) {
            var pos = {
                "left": x,
                "top": y + 30
            };
            var _tw = tooltip.element.outerWidth();
            var _th = tooltip.element.outerHeight();

            if (pos.left + _tw > document.body.scrollWidth - 10)
                pos.left = tooltip.size.width - 10 - _tw;
            if (pos.top + _th > document.body.scrollHeight - 10)
                pos.top -= (_th + 40);
            return pos;
        },

        "show": function (e) {
            if (tooltip.element) {
                var message = e.currentTarget.dataset.tooltip;
                if (message) {
                    tooltip.element.html(message);
                    tooltip.element.css(tooltip.position(e.pageX, e.pageY)).stop(true, true).fadeIn("fast");
                    jQuery(e.currentTarget).unbind("mousemove.tooltip").bind("mousemove.tooltip", tooltip.moving);
                }
            }
        },

        "moving": function (e) {
            if (tooltip.element) {
                tooltip.element.css(tooltip.position(e.pageX, e.pageY));
            }
        },

        "hide": function (e) {
            if (tooltip.element) {
                jQuery(e.currentTarget).unbind("mousemove.tooltip");
                tooltip.element.stop(true, true).fadeOut("fast");
            }
        }
    };

    var confirm = {

        events: function (submit, cancel) {
            jQuery("div.msg-message").on("click", "> .msg-button .submit", function () {
                $(".msg-bg").fadeOut("fast");
                submit();
            }).on("click", "> .msg-button .cancel", cancel);
        },

        init: function (type, setting, submit, cancel) {
            var defStyle = {
                bg: {
                    backgroundColor: "#eaeaea",
                    position: "fixed",
                    top: 0,
                    width: "100%",
                    height: "100%"
                },
                wrap: {
                    width: "200px",
                    height: "100px",
                    backgroundColor: "#fff",
                    fontFamily: "Roboto Condensed",
                    border: "#ccc",
                    position: "absolute",
                    left: "50%",
                    top: "50%"
                },
                content: {
                    padding: "10px 10px"
                }
            },
                defSetting = {};

            switch (type) {
                case "confirm":
                    $.extend(true, defStyle, {
                        title: {
                            padding: "10px 10px",
                            backgroundColor: "#39aeff",
                            fontSize: "15px",
                            color: "#fff"
                        },
                        button: {
                            width: "50%",
                            fontSize: "13px",
                            padding: "10px 0",
                            textAlign: "center",
                            border: "none",
                            fontFamily: "Roboto Condensed",
                            color: "#fff",
                            cursor: "pointer",
                            outline: "none"
                        },
                        buttonSubmit: {
                            backgroundColor: "#3296f4"
                        },
                        buttonCancel: {
                            backgroundColor: "#838383"
                        }
                    });
                    defSetting = {
                        title: "title",
                        ico: "",
                        content: "content",
                        submit: "ok",
                        cancel: "no",
                        style: defStyle
                    };
                    break;
                case "message":
                    $.extend(true, defStyle, {
                        button: {
                            padding: "8px",
                            fontSize: "13px",
                            textAlign: "center",
                            border: "none",
                            fontFamily: "Roboto Condensed",
                            cursor: "pointer",
                            outline: "none",
                            position: "absolute",
                            right: "10px"
                        },
                        buttonSubmit: {
                            backgroundColor: "transparent",
                            color: "#000"
                        }
                    });
                    defSetting = {
                        content: "show your message",
                        submit: "ok",
                        style: defStyle
                    };
                    break;
                case "shortmessage":

                    break;
            }
            if ($.isPlainObject(setting) && !$.isEmptyObject(setting)) {
                $.extend(true, defSetting, setting);
            }
            var bg = '<div class="msg-bg"></div>', msgHtml = "";
            if (type === "confirm") {
                msgHtml = '<div class="msg-message"> <div class="msg-title"> <span class="{0}"></span> <span>{1}</span> </div> <div class="msg-content"> {2} </div> <div class="msg-button"> <button class="submit">{3}</button><button class="cancel">{4}</button> </div> </div>'.format(defSetting.ico, defSetting.title, defSetting.content, defSetting.submit, defSetting.cancel);
            } else if (type === "message") {
                msgHtml = '<div class="msg-message"> <div class="msg-content"> {0} </div> <div class="msg-button"> <button class="submit">{1}</button></div> </div>'.format(defSetting.content, defSetting.submit);
            }

            _body.prepend($(bg).append(msgHtml));

            var ms = $(".msg-message");
            $(".msg-bg").css(defSetting.style.bg);
            ms.css(defSetting.style.wrap);
            $(".msg-content").css(defSetting.style.content);
            $(".msg-button > button.submit").css(defSetting.style.buttonSubmit);
            if (type === "confirm") {
                $(".msg-title").css(defSetting.style.title);
                $(".msg-button > button").css(defSetting.style.button);
                $(".msg-button > button.cancel").css(defSetting.style.buttonCancel);
            } else if (type === "message") {
                $(".msg-button").css({ position: "relative" });
                $(".msg-button > button").css(defSetting.style.button);
            }

            var w = ms.width(),
                h = ms.height();
            ms.css({
                marginLeft: -(w / 2) + "px",
                marginTop: -(h / 2) + "px"
            });
            if ($.isFunction(submit) || $.isFunction(cancel)) {
                if (type === "confirm") {
                    confirm.events(submit, cancel);
                } else if (type === "message") {
                    confirm.events(submit);
                }
            }

        }
    };

    jQuery.extend({
        tooltip: function (setting) {
            tooltip.init(setting);
        }
    });
    jQuery.extend({
        confirm: function (setting, submit, cancel) {
            confirm.init("confirm", setting, submit, cancel);
        }
    });
    jQuery.extend({
        message: function (setting, submit) {
            confirm.init("message", setting, submit);
        }
    });
    jQuery.extend({
        shortmessage: function (setting, submit, cancel) {
            confirm.init("shortmessage", setting, submit, cancel);
        }
    });
})(jQuery);