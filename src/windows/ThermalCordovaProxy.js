var cordova = require('cordova'),
    ThermalCordova= require('./ThermalCordova');

module.exports = {

    ToUpper: function (successCallback, errorCallback, strInput) {

        var upperCase = strInput[0].toUpperCase();
        if(upperCase != "") {
            successCallback(upperCase);
        }
        else {
            errorCallback(upperCase);
        }
    }
};

require("cordova/exec/proxy").add("ThermalCordova", module.exports);