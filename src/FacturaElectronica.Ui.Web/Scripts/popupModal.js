//  keeps track of the delete button for the row
//  that is going to be removed
var _source;
// keep track of the popup div
var _popup;

function showConfirm(source) {
    this._source = source;
    this._popup = $find('mdlPopup');

    //  find the confirm ModalPopup and show it    
    this._popup.show();
}

function okClick() {
    //  find the confirm ModalPopup and hide it    
    this._popup.hide();
    //  use the cached button as the postback source
    __doPostBack(this._source.name, '');
}

function cancelClick() {
    //  find the confirm ModalPopup and hide it 
    this._popup.hide();
    //  clear the event source
    this._source = null;
    this._popup = null;
}
