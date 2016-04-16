

function ErrorPanel() {

    var _I = this;
    _I.elementErrorPanel = $('#pnlMessages');
    _I.elementErrorTitle = $('#txtErrorTitle');
    _I.elementErrorTxtMessege = $('#txtMessages');
   
    this.showMessage = function (title, message) {

        _I.elementErrorPanel.removeClass('displayNone').addClass('displayBlock');     

        _I.elementErrorTitle.html(title);
        _I.elementErrorTxtMessege.html(message);

    }

    this.showError = function (title, message) {
        _I.elementErrorPanel.removeClass('displayNone');
        _I.elementErrorPanel.addClass('displayBlock');

        _I.elementErrorTitle.html(title);
        _I.elementErrorTxtMessege.html(message);
    }

    this.appendAsterisk = function (controlId) {

        $('#' + controlId).after('<span class="errorAsterisk" >*</span>');

    }

}








