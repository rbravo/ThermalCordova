var ThermalCordova = {
    ToUpper: function (successCallback, errorCallback, strInput) {
        cordova.exec(successCallback, errorCallback, "ThermalCordova", "ToUpper", [strInput]);
    }
}

module.exports = ThermalCordova;