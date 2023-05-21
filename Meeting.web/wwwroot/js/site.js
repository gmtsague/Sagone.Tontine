// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function DisplayForm(formTitle, AnchorId, event) {

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
                $('#partialModal-body').html(data);
                if (formTitle) {
                    $('#partialModal .modal-title').html(formTitle);

                    if ($('#partialModal .partialSubmitBtn') && $('#partialModal .partialSubmitBtn').length > 0) {

                        if ($('#partialModal .partialSubmitBtn').hasClass('btn-danger')) {

                            $('#partialModal .partialSubmitBtn').addClass('btn-primary');
                            $('#partialModal .partialSubmitBtn').removeClass('btn-danger');
                        }

                        if (formTitle.indexOf("Create") >= 0 || formTitle.indexOf("Nouveau") >= 0)
                            $('#partialModal .partialSubmitBtn')[0].value = 'Create';
                        else if (formTitle.indexOf("Edit") >= 0 || formTitle.indexOf("Update") >= 0)
                            $('#partialModal .partialSubmitBtn')[0].value = 'Save';
                        else if (formTitle.indexOf("Delete") >= 0 || formTitle.indexOf("Supprimer") >= 0) {
                            $('#partialModal .partialSubmitBtn')[0].value = 'Delete';
                            $('#partialModal .partialSubmitBtn').removeClass('btn-primary');
                            $('#partialModal .partialSubmitBtn').addClass('btn-danger');
                        }
                    }

                    if ($('#partialModal .modal-footer') && $('.modal-footer').length > 0) {

                        if (formTitle.indexOf("Details") >= 0 || formTitle.indexOf("Détails") >= 0)
                            $('#partialModal .modal-footer')[0].style.visibility = 'hidden';
                       // else if (formTitle.indexOf("Delete") >= 0 || formTitle.indexOf("Supprimer") >= 0)
                       //     $('#partialModal .modal-footer')[0].style.visibility = 'hidden';
                        else
                            $('#partialModal .modal-footer')[0].style.visibility = 'visible';
                    }

                }

               // $('#partialSubmitBtn').unbind("click", TriggerSubmitFormBtn);
               // $('#partialSubmitBtn').bind("click", TriggerSubmitFormBtn);

//                $('#partialModal .partialSubmitBtn').click(TriggerSubmitFormBtn);

                $('#partialModal .partialSubmitBtn').click(function () {
                    //$('#partialModal .btn-primary').closest('form')[0].submit(); ///N'utilise pas le mécanisme AJAX pendant la soumission du formulaire
                    //$('#partialModal .card-body').find('form')[0].submit(); ///N'utilise pas le mécanisme AJAX pendant la soumission du formulaire
                    if (formTitle.indexOf("Delete") >= 0 || formTitle.indexOf("Supprimer") >= 0)
                        $('#partialModal .modal-body .btn-danger').click();
                    else
                        $('#partialModal .card-body .btn-primary').click();
                });
                
               // $("#partialModal").modal("show");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        })
        return false;
    }
    catch (excep) {
        alert(PanicMessage);
        console.log(PanicMessage)
    }
}


function DisplayPresenceModalForm(formTitle, event) {

    var targetUrl = null;
    var PanicMessage = "An error occured! Cannot get the Path to server.\n Please contact the software editor.";

    try {
        if (event && event.currentTarget)
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
                $('#presenceModalForm-body').html(data);
                if (formTitle) {
                    $('#presenceModalForm .modal-title').html(formTitle);

                    if ($('#presenceModalForm .partialSubmitBtn') && $('#presenceModalForm .partialSubmitBtn').length > 0) {

                        if (formTitle.indexOf("Create") >= 0 || formTitle.indexOf("Nouveau") >= 0)
                            $('#presenceModalForm .partialSubmitBtn')[0].value = 'Create';
                        else if (formTitle.indexOf("Edit") >= 0 || formTitle.indexOf("Update") >= 0)
                            $('#presenceModalForm .partialSubmitBtn')[0].value = 'Save';
                    }

                    if ($('#presenceModalForm .modal-footer') && $('#presenceModalForm .modal-footer').length > 0) {

                        if (formTitle.indexOf("Details") >= 0 || formTitle.indexOf("Détails") >= 0)
                            $('#presenceModalForm .modal-footer')[0].style.visibility = 'hidden';
                        else if (formTitle.indexOf("Delete") >= 0 || formTitle.indexOf("Supprimer") >= 0)
                            $('#presenceModalForm .modal-footer')[0].style.visibility = 'hidden';
                        else
                            $('#presenceModalForm .modal-footer')[0].style.visibility = 'visible';
                    }

                }

                // $('#partialSubmitBtn').unbind("click", TriggerSubmitFormBtn);
                // $('#partialSubmitBtn').bind("click", TriggerSubmitFormBtn);

                $('#presenceModalForm .partialSubmitBtn').click(function () {
                    //$('#presenceModalForm .btn-primary').closest('form')[0].submit(); ///N'utilise pas le mécanisme AJAX pendant la soumission du formulaire
                   // $('#presenceModalForm .card-body').find('form')[0].submit(); ///N'utilise pas le mécanisme AJAX pendant la soumission du formulaire
                    $('#presenceModalForm .card-body .btn-primary').click();
                });
               // $("#presenceModalForm").modal("show");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        })
        return false;
    }
    catch (excep) {
        alert(PanicMessage);
        console.log(PanicMessage)
    }
}


function DisplaySeanceDetailsModalForm(formTitle, AnchorId, event) {

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
                $('#SeancePresencesModalForm-body').html(data);
                if (formTitle) {
                    $('#SeancePresencesModalForm .modal-title').html(formTitle);
                }

             //   $("#SeancePresencesModalForm").modal("show");
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        })
        return false;
    }
    catch (excep) {
        alert(PanicMessage);
        console.log(PanicMessage)
    }
}


function TriggerSubmitFormBtn() {
    //alert('tentative de submit' + $('#modalForm')[0].action);
    if ($('#regularSubmitBtn'))
        $('#regularSubmitBtn').click();

    // $('#modalForm')[0].submit();
    // alert($('#regularSubmitBtn')[0].id);
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


function OnUndoPaiement(event, idValue) {

    var targetUrl = null;
    if (event && event.currentTarget)
        targetUrl = event.currentTarget.href;

    if (!confirm("Voulez-vous vraimemnt annuler les opérations financières \nde cette séance de reunion pour le membre sélectionné ?"))
        return false;

    $.ajax({
        type: "POST",
        url: targetUrl,
        data: { id: idValue},
        //contentType: "application/text; charset=utf-8",
        //dataType: "html",
        async: true,

        success: function (data) {
            fhToastr.success(data.message);
        },
        failure: function (response) {
            fhToastr.error(data.responseText);
            console.log(response.responseText);
        },
        error: function (response) {
            fhToastr.warning(data.responseText);
            console.log(response.responseText);
        }

    });

    return false;
}

//------------------------------------------------

function handleSubmit(event) {
    event.preventDefault();

    const data = new FormData(event.target);
    const value = Object.fromEntries(data.entries());

    //value.topics = data.getAll("topics");
    console.log({ value });
}

const form = document.querySelector("form");
form.addEventListener("submit", handleSubmit);

//-------------------------------------------------

function SetWorkingSessionYear(baseurl, obj) {
    var value = obj.value;
    //var url = "@baseurl";
    $.post(baseurl + "Annees/SetDefault/"+value, { AnneeId: value }, function (data) {
       // debugger;
       // PopulateDropDown("#ddlProductId", data);
    });
}

function SetWorkingSessionEtab(baseurl, obj) {
    var value = obj.value;
    //var url = "@baseurl";
    //$.post(baseurl + "Etablissements/SetDefault/" + value, { id: value }, function (data) {
    //   // debugger;
    //   // PopulateDropDown("#ddlProductId", data);
    //});

    $.ajax({

        type: "POST",
        url: baseurl + "Etablissements/Setdefault/",
        //contentType: "application/json; charset=utf-8",
        //contentType: false,
        //processData: true,
       // dataType: "json",
        data: "id="+value ,
       // enctype:'multipart/form-data',
        async: true,
        cache:false,

        success: function (data) {
          //  $('.modal-body').html(data);
            alert('OK');

        },
        failure: function (response) {
            alert(response.responseText);
            console.log(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
            console.log(response.responseText);
        }

    })
}

function SetWorkingSessionAntenne(baseurl, obj) {
    var value = obj.value;
    //var url = "@baseurl";
    $.post(baseurl + "Antennes/SetDefault", { AntenneId: value }, function (data) {
       // debugger;
       // PopulateDropDown("#ddlProductId", data);
    });
}

function SetWorkingSessionYear000(formTitle, AnchorId, event) {

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

            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }

        })
        return false;
    }
    catch (excep) {
        alert(PanicMessage);
        console.log(PanicMessage)
    }
}

function loadProduct(obj) {
    var value = obj.value;
    var url = "@baseurl";
    $.post(url + "Products/GetProductsByCategoryId", { categoryId: value }, function (data) {
        debugger;
        PopulateDropDown("#ddlProductId", data);
    });
}

function PopulateDropDown(dropDownId, list, selectedId) {
    $(dropDownId).empty();
    $(dropDownId).append("<option>--Please Product--</option>")
    $.each(list, function (index, row) {
        $(dropDownId).append("<option value='" + row.id + "'>" + row.name + "</option>")
    });
}