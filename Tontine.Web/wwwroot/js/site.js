// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function DisplayForm(AnchorId, event) {

    var targetUrl = null;
    var PanicMessage = "An error occured! Cannot get the Path to server.\n Please contact the software editor.";

    try {
        if (AnchorId) {
            var linkObj = document.getElementById(AnchorId);
            if (linkObj)
                targetUrl = linkObj.href;
            else
                throw (PanicMessage);
        }
        else if (event && event.currentTarget)
            targetUrl = event.currentTarget.href;
        else {
            throw (PanicMessage);
        }

        $.ajax({

            type: "GET",
            url: targetUrl,
            contentType: "application/text; charset=utf-8",
            dataType: "html",
            async: false,

            success: function (data) {
                $('.modal-body').html(data);

                $("#partialModal").modal("show");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        })
    }
    catch (excep) {
        alert(PanicMessage);
        console.log(PanicMessage)
    }
}

function DefineCustomMonthNameFromDate(src) {
    // $(#Libelle).attr('value') =  moment(src.value).format("MMMM-YYYY");
    document.getElementById('Libelle').value = moment(src.value).format("MMMM-YYYY");
}
function DefineCustomNumOrderFromMonthDate(src) {
    // $(#Numordre).attr('value') =  moment(src.value).format("MM");
    document.getElementById('Numordre').value = moment(src.value).format("MM");
}

function DefineCustomNumOrderAndMonthNameFromDate(src) {
    DefineCustomMonthNameFromDate(src);
    DefineCustomNumOrderFromMonthDate(src)
}