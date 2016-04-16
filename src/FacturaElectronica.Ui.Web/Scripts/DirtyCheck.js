


function DirtyCheck() {   
    var _I = this;    
    
    _I.controls = new Array();
    _I.selectorString = '.inputs, input[type=checkbox], input[type=file], .cPlanProdInputCant, .cbo, .chk';
    _I.isForcedDirty = false;

    this.loadControlState = function () {       
            
        $(_I.selectorString).each(function () {
            var name = $(this).attr('id');
            var val = $(this).val();
            _I.controls[name] = val;
        });
    }

    this.forceDirty = function () {
        _I.isForcedDirty = true;
    }

    this.areControlsDirty = function () {

        if (_I.isForcedDirty) {
            return _I.isForcedDirty;
        }
        else {
            var isDirty = false;

            $(_I.selectorString).each(function () {
                var name = $(this).attr('id');
                var val = $(this).val();
                if (_I.controls[name] != val) {
                    isDirty = true;
                    return false;
                }
            });

            return isDirty;
        }
    }

    this.showControls = function () {

        for (var ctrl in _I.controls) {
            alert('' + ctrl + ':' + _I.controls[ctrl]);
        }
    }

}