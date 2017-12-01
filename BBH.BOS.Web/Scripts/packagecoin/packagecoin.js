﻿function ShowpopupEditpackageCoin(packageID, coinID, packageValue)
{
    $('#hdPackageID').val(packageID);
    $('#hdCoinID').val(coinID);
    $('#cbPackage option[value=' + packageID + ']').attr('selected', true);
    $('#cbPackage').trigger('chosen:updated')
    $('#cbCoin option[value=' + coinID + ']').attr('selected', true);
    $('#cbCoin').trigger('chosen:updated')
    //$('#txtCoinID').val(coinID);
    $('#txtPackageValue').val(packageValue);
    
    setTimeout(function () {
        $('#cbPackage').chosen({
            width: '200px'
        },500);
    }, 500);
    setTimeout(function () {
        $('#cbCoin').chosen({
            width: '200px'
        });
    }, 500);
}
function ShowPopupInsert()
{
    $('#cbPackage option[value=0]').attr('selected', true);
    $('#cbCoin option[value=0]').attr('selected', true);
    $('#txtPackageValue').val('');
}
function ConfirmPackage_Coin(packageID,coinID, isDelete) {
    var textMessage = '';
    textMessage = 'Are you sure delete this package_Coin?';
  
    var confirmMessage = confirm(textMessage);
    if (!confirmMessage) {
        return false;
    }
    else {
        $('#imgLoading_' + packageID).css("display", "");
        $.ajax({
            type: "post",
            async: false,
            url: "/Package_Coin/UpdateIsDeletePackageCoin",
            data: { packageID: packageID,coinID:coinID, isDelete: isDelete },
            beforeSend: function () {
                $('#imgLoading_' + packageID).css("display", "");
            },
            success: function (d) {
                $('#imgLoading_' + packageID).css("display", "none");
                if (d == 'success') {
                    noty({ text: "Update Success", layout: "bottomRight", type: "information" });

                    setTimeout(function () { window.location.reload(); }, 2000);
                }
                else if (d == 'PackageCoinIDExist')
                {
                    noty({ text: "Package_Coin Exist", layout: "bottomRight", type: "error" });
                }
                else {

                    noty({ text: "Update Error. Please contact admin", layout: "bottomRight", type: "error" });
                }
            },
            error: function (e) {

            }
        });
    }
}
function ResetForm(id, value) {
    $('#' + id).text('');
    $('#' + id).css('display', 'none');
}
//function functionx(evt) {
//    if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
//        alert("Allow Only Numbers");
//        return false;
//    }
//}
function SavePackageCoin() {
    var checkReg = true;
    var packageID = $('#cbPackage').val();
    var coinID = $('#cbCoin').val();
    //var coinID = $('#txtCoinID').val();
  
    var packageValue = $('#txtPackageValue').val();

    if (packageID == 0) {
        $('#lbErrorPackage').text('Please select function');
        $('#lbErrorPackage').css('display', '');
        checkReg = false;
    }

    if (coinID == 0) {
        $('#lbErrorCoinID').text('Please input id coin ');
        $('#lbErrorCoinID').css('display', '');
        checkReg = false;
    }

    if (packageValue == '') {
        $('#lbErrorPackageValue').text('Please input packagecoin name');
        $('#lbErrorPackageValue').css('display', '');
        checkReg = false;
    }

    

   
    if (!checkReg) {
        return false;
    }
    else {
        $('#imgLoading').css("display", "");
        $.ajax({
            type: "post",
            async: true,
            url: "/Package_Coin/SavePackageCoin",
            data: { packageID: packageID, coinID: coinID, packageValue: packageValue },
            beforeSend: function () {
                $('#imgLoading').css("display", "");
            },
            success: function (d) {
                $('#imgLoading').css("display", "none");
                if (d == 'Updatesuccess') {
                    noty({ text: "Update success", layout: "bottomRight", type: "information" });
                    setTimeout(function () { window.location.reload(); }, 1000);
                }
               
                else if (d == 'Updatefaile') {
                    alertify.error('Updatefaile');
                }
                else if (d == 'PackageCoinIDExist') {
                    noty({ text: "Package_Coin Exist", layout: "bottomRight", type: "error" });
                }
                else if (d == 'error') {
                    alertify.error('error! please contact admin');
                }

            },
            error: function (e) {

            }
        });
    }
}
function UpdatePackageCoin() {
    var checkReg = true;
    var packageID = $('#cbPackage').val();
    //var coinID = $('#cbCoin').val();
    var coinID = $('#txtCoinID').val();

    var packageValue = $('#txtPackageValue').val();


    if (packageValue == '') {
        $('#lbErrorPackageValue').text('Please input packagecoin name');
        $('#lbErrorPackageValue').css('display', '');
        checkReg = false;
    }

    if (coinID == '') {
        $('#lbErrorCoinID').text('Please input id coin ');
        $('#lbErrorCoinID').css('display', '');
        checkReg = false;
    }

    if (packageID == '0') {
        $('#lbErrorGroupAdmin').text('Please select function');
        $('#lbErrorGroupAdmin').css('display', '');
        checkReg = false;
    }
    if (!checkReg) {
        return false;
    }
    else {
        $('#imgLoading').css("display", "");
        $.ajax({
            type: "post",
            async: true,
            url: "/Package_Coin/UpdatePackageCoin",
            data: { packageID: packageID, coinID: coinID, packageValue: packageValue },
            beforeSend: function () {
                $('#imgLoading').css("display", "");
            },
            success: function (d) {
                $('#imgLoading').css("display", "none");
                if (d == 'Updatesuccess') {
                    noty({ text: "Update success", layout: "bottomRight", type: "information" });
                    setTimeout(function () { window.location.reload(); }, 1000);
                }

                else if (d == 'Updatefaile') {
                    alertify.error('Updatefaile');
                }
                else if (d == 'error') {
                    alertify.error('error! please contact admin');
                }

            },
            error: function (e) {

            }
        });
    }
}

