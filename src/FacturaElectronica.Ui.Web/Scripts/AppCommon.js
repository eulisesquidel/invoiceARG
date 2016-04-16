



function AppCommon() {

    var _I = this;

    this.UIHelper = {};
    this.UIHelper.Null = '-1';

    var actualFormSubmit = $(document).find('form').attr('onsubmit');
    if (!actualFormSubmit) {
        actualFormSubmit = '';
    }    

    $(document).find('form').attr('onsubmit',
          actualFormSubmit +  " $('input[title],textarea[title]').each(function () { AppCommonObj.hideHints(this);  }); return true;"    
        );


    this.hideHints = function (el) {        
        if ($(el).val() == $(el).attr('title'))
            $(el).val('').removeClass('hint');
    };

    this.toggleVisibility = function (imgName, divFilterName) {
        var imgExpand = $('#' + imgName);
        var containerFilter = $('#' + divFilterName);

        if (containerFilter.length != 0) {

            containerFilter.slideToggle(300, function () {

                if (containerFilter.is(':hidden')) {
                    imgExpand.attr("src", "/Images/icon_blockcollapsed.png");
                }
                else {
                    imgExpand.attr("src", "/Images/icon_blockexpanded.png");
                }
            });
        }
    };

    this.initializeEnterKeyEvent = function (areaCtr, func) {
        areaCtr.keydown(function (e) {

            var key = e.which || e.keyCode;

            if (key == 13) {
                func();
            }
        });
    };

    this.HandleCheckRow = function (check) {

        // los valores los guardo como #3#45#
        // alert(check.checked);
        var valorIdCustomer = $(check).closest('tr').find('.gridid').val();
        var strCheck = $('#hidCheckedRows').val();

        var separador = '';
        if (strCheck.length == 0) {
            separador = '#'
        }

        // selecciono o deselecciono el valor
        if (check.checked) {
            // lo agrego
            strCheck += separador + valorIdCustomer + '#';
        }
        else {
            // lo elimino
            strCheck = strCheck.replace('#' + valorIdCustomer + '#', '#');
        }

        $('#hidCheckedRows').val(strCheck);
    };   
}


// Validaciones

function isIntegerNumber(valor) {
    var RE = /^[0-9]*$/;
    return (RE.test(valor));
}

function handleJustNumber (inputCtrl) {
    inputCtrl.value = inputCtrl.value.replace(/[^0-9\.]/g, '');
};


function ConfirmDeletionSimple() {

    return confirm('Está seguro que desea eliminar los registros?');
}

function ConfirmGoBack() {

    return confirm('Está seguro que desea volver');
}

function AdEngineDownMenu(menu_id) {

    //config
    var float_speed = 1500; //milliseconds
    //$float_easing = "easeOutQuint";
    var menu_fade_speed = 500; //milliseconds
    var closed_menu_opacity = 0.75;

    //cache vars
    var fl_menu = $("#" + menu_id);
    var fl_menu_menu = $("#" + menu_id + "  .menu_cmd");
    var fl_menu_label = $("#" + menu_id + "  .label_cmd");

    fl_menu.hover(
                function () { //mouse over
                    fl_menu_label.fadeTo(menu_fade_speed, 1);
                    fl_menu_menu.fadeIn(menu_fade_speed);
                    fl_menu_label.addClass('menu_cmd_black');
                },
                function () { //mouse out                    
                    fl_menu_label.fadeTo(menu_fade_speed, closed_menu_opacity);
                    fl_menu_menu.fadeOut(menu_fade_speed);
                    fl_menu_label.removeClass('menu_cmd_black');
                }
             );    
};

function postData(caller, callerEventTarget) {
    var __theFormPostData = '';
    var theForm = document.forms[0];
    var sep = '';
    var count = theForm.elements.length;
    var element;
    var tag;
    var tipo;
    for (i = 0; i < count; i++) {
        element = theForm.elements[i];
        if (element.name != '') {
            tag = element.tagName.toLowerCase();
            if (element.type) {
                tipo = element.type.toLowerCase();

                if (tag == 'input') {
                    if ((tipo != 'button') && (tipo != 'submit') && (tipo != 'checkbox')) {
                        if (tipo == 'hidden' && element.name == '__EVENTTARGET') {
                            __theFormPostData += sep + encodeURIComponent(element.name) + '=' + encodeURIComponent(callerEventTarget/*caller.name ? caller.name : caller.id*/);
                        }
                        else
                            __theFormPostData += sep + encodeURIComponent(element.name) + '=' + encodeURIComponent(element.value);
                        sep = '&';
                    }
                    else if (tipo == 'checkbox' && element.checked) {
                        __theFormPostData += sep + encodeURIComponent(element.name) + '=' + encodeURIComponent(element.value);
                        sep = '&';
                    }
                }
                else if (tag == 'select') {
                    selectCount = element.children.length;
                    for (j = 0; j < selectCount; j++) {
                        selectChild = element.children[j];
                        if ((selectChild.tagName.toLowerCase() == 'option') && (selectChild.selected == true)) {
                            __theFormPostData += sep + encodeURIComponent(element.name) + '=' + encodeURIComponent(selectChild.value);
                            sep = '&';
                        }
                    }
                }
            }
        }
    }

    if (caller.type)
        tipo = caller.type.toLowerCase();
    if (caller.tagName)
        tag = caller.tagName.toLowerCase();
    /* if( ( tag == 'input') && ( (tipo == 'button')|| (tipo == 'submit')  ) )
    __theFormPostData += sep + encodeURIComponent(caller.name) + '=' + encodeURIComponent(caller.value);
    else */
    if ((tag == 'input') && (tipo == 'image')) {
        __theFormPostData += sep + encodeURIComponent(caller.name) + '.x=' + event.x;
        __theFormPostData += sep + encodeURIComponent(caller.name) + '.y=' + event.y;
    }
    return __theFormPostData;
}









