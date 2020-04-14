/*
	vanchi.js.modaldialog
*/
var vanchi_js_modaldialog = {
    getDialog: function (childElement) {
        if (childElement != undefined) {

            return $(childElement).closest('.ui-dialog-content');
        }
        return null;

    },
    getDialogArgs: function (dialog) {
        return $(dialog).data('Args');
    }
    ,
    setDialogReturnValue: function (dialog, returnValue) {
        $(dialog).data('ReturnValue', returnValue);
    }
    ,
    closeDialog: function (dialog, returnValue) {
        vanchi_js_modaldialog.setDialogReturnValue(dialog, returnValue);
        $(dialog).dialog('close');

    }
    ,
    showDialog: function (options, callBackFunction) {
        // show a spinner or something via css
        var $dialog = $('<div style="display:none" class="loading"></div>').appendTo('body');
        // open the dialog
        $dialog.dialog({
             appendTo: options.appendTo == undefined ? 'body' : options.appendTo,
            autoOpen: options.autoOpen == undefined ? true : options.autoOpen,
            buttons: options.buttons == undefined ? [] : options.buttons,
            closeOnEscape: options.closeOnEscape == undefined ? true : options.closeOnEscape,
            closeText: options.closeText == undefined ? 'close' : options.closeText,
            dialogClass: options.dialogClass == undefined ? '' : options.dialogClass,
            draggable: options.draggable == undefined ? true : options.draggable,
            height: options.height == undefined ? 'auto' : options.height,
            hide: options.hide == undefined ? null : options.hide,
            maxHeight: options.maxHeight == undefined ? $(window).height() : options.maxHeight,
            maxWidth: options.maxWidth == undefined ? $(window).width() : options.maxWidth,
            minHeight: options.minHeight == undefined ? 150 : options.minHeight,
            minWidth: options.minWidth == undefined ? 150 : options.minWidth,
            //modal: options.modal == undefined ? true : options.modal,
              modal: false,
            position: options.position == undefined ? { my: "center", at: "center", of: window } : options.position,
            resizable: options.resizable == undefined ? true : options.resizable,
            show: options.show == undefined ? null : options.show,
            title: options.title == undefined ? null : options.title,
            width: options.width == undefined ? 300 : options.width,
            beforeClose: options.beforeClose,
            close: function (event, ui) {
                if ($('.ui-dialog').length == 1) {
                    $("body").css({ overflow: 'inherit' })
                }
                //remove div with all data and events
                var returnValue = $(this).data('ReturnValue');
                if (typeof (callBackFunction) == 'function') {
                    callBackFunction(returnValue);

                }
                if (typeof (options.close) == 'function') {
                    options.close(event, ui);
                }

                $(this).remove();
            },
            create: options.create,
            drag: options.drag,
            dragStart: options.dragStart,
            dragStop: options.dragStop,
            focus: options.focus,
            open: function (event, ui) {
                $("body").css({ overflow: 'hidden' })
                $('.ui-widget-overlay').unbind( "click" );
                $('.ui-widget-overlay').on('click', function () {
                    $(this).find('+ div').find('.ui-dialog-content').dialog("close");
                });
                $(this).data('Args', options.args);
                if (typeof (options.open) == 'function') {
                    options.open(event, ui);
                }
                
            },
            resize: options.resize,
            resizeStart: options.resizeStart,
            resizeStop: options.resizeStop,

        });

        // load remote content
        $dialog.load(options.url);
    },

};
