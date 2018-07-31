﻿var newRows = [], deletedRows = [], updatedRows = [];

function navDataSetHelper() {
    this.columnNames = [{
        "name": "caseNo",
        "label": "Case Number",
        "width": 90,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "plaintiff",
        "label": "Plaintiff",
        "width": 72,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "defendant",
        "label": "Defendant",
        "width": 90,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "country",
        "label": "Country",
        "width": 75,
        "columnType": {
            type: 'dropdown',
            source: getSourceCountries()
        }
    }, {
        "name": "dateOfFiling",
        "label": "Date Of Filing",
        "width": 100,
        "columnType": {
            type: 'calendar'
        }
    }, {
        "name": "courtOfLaw",
        "label": "Court Of Law",
        "width": 92,
        "columnType": {
            type: 'dropdown',
            source : getSourceCourts()
        }
    }, {
        "name": "sequel",
        "label": "Sequel",
        "width": 70,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "judgeName",
        "label": "Judge Name",
        "width": 95,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "typeOfSuit",
        "label": "Type Of Suit",
        "width": 115,
        "columnType": {
            type: 'dropdown',
            source: getSourceSuits()
        }
    }, {
        "name": "relatedTo",
        "label": "Related To",
        "width": 68,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "underSection",
        "label": "Under Section",
        "width": 66,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "patentsAtIssue",
        "label": "Patents At Issue",
        "width": 65,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "caseSummary",
        "label": "Case Summary",
        "width": 290,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "courtInterpretation",
        "label": "Court Interpretation",
        "width": 106,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "dateOfJudgement",
        "label": "Date Of Judgement",
        "width": 115,
        "columnType": {
            type: 'calendar'
        }
    }, {
        "name": "caseDecision",
        "label": "Case Decision",
        "width": 80,
        "columnType": {
            type: 'text'
        }
    }, {
        "name": "furtherAppeals",
        "label": "Further Appeals",
        "width": 84,
        "columnType": {
            type: 'text'
        }
    },    {
        "name": "status",
        "label": "Status",
        "width": 80,
        "columnType" : {
            type : "dropdown",
            source : getSourceStatuses()
        }
    },{
        "name": "caseInDetail",
        "label": "Case In Detail",
        "width": 400,
        "columnType": {
            type: 'text'
        }
    },{
        "name": "flowchart",
        "label": "Flowchart",
        "width": 113,
        "columnType": {
            type: 'text'
        }
    }]
}

navDataSetHelper.prototype.dataSetHandler = function (event, that) {
    var form = $(that);
    //event.preventDefault();
    /*form.validate({
     errorClass : "error help-block",
     rules : {
         email : {
             required : true,
             email : true
         }
     },
     messages : {
         email : {
             required : "Please specify an email address",
             email : "Invalid email address"
         }
     },
     errorElement: "em",
     highlight : function(element, errorClass, validClass) {
         $(element).parent().addClass('has-error');
     },
     submitHandler : self.saveDataSet
    })*/
    $("#_nav_bird_eye_view_button").prop('disabled', true);
    var self = this;
    this.saveDataSet(form)
        .then(function (response) {
            self.showSuccess(response.body.body.message);
            $("#_nav_bird_eye_view_success .alert-success").focus();
            $("#_nav_bird_eye_view_button").prop('disabled', false);
        })
    .catch(function (error) {
        if (typeof error == "string") {
            self.showError(error);
        } else {
            self.showError(error.body.subMessage);
        }
        $("#_nav_bird_eye_view_button").prop('disabled', false);
    });
}

navDataSetHelper.prototype.saveDataSet = function (form) {
    var body = form.serialize();
    //console.log(body);
    return navRequestHandler().doRequest(form.attr('action'), 'POST', body);
}

navDataSetHelper.prototype.showError = function (message) {
    $("#_nav_bird_eye_view_error .alert").text(message);
    $("#_nav_bird_eye_view_error").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_bird_eye_view_error").offset().top
    }, 'slow');
}

navDataSetHelper.prototype.showSuccess = function (message) {
    $("#_nav_bird_eye_view_success .alert-success").text(message);
    $("#_nav_bird_eye_view_success").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_bird_eye_view_success").offset().top
    }, 'slow');
}

navDataSetHelper.prototype.hideError = function () {
    $("#_nav_bird_eye_view_error .alert-danger").text("");
    $("#_nav_bird_eye_view_error").addClass("d-none");
}

navDataSetHelper.prototype.hideSuccess = function () {
    $("#_nav_bird_eye_view_success .alert-success").text("");
    $("#_nav_bird_eye_view_success").addClass("d-none");
}

navDataSetHelper.prototype.onInsertNewRow = function (obj) {
    newRows.push($(obj).last());
}

navDataSetHelper.prototype.onDeleteRow = function (obj) {
    
}

navDataSetHelper.prototype.onChangeRow = function(obj, cell, val) {
}

registerDataSetHandlers();

function registerDataSetHandlers() {
    $("#_nav_bird_eye_view_button").click(function (event) { new navDataSetHelper().dataSetHandler(event, this) });
    data = [
            ['Mazda', 2001, 2000, 0 , '2018-08-02'],
            ['Pegeout', 2010, 5000],
            ['Honda Fit', 2009, 3000],
            ['Honda CRV', 2010, 6000],
    ];

    var d = new navDataSetHelper();
    var headers = [], widths = [], types = [];

    for (var i = 0; i < d.columnNames.length; i++) {
        headers.push(d.columnNames[i].label);
        widths.push(d.columnNames[i].width);
        types.push(d.columnNames[i].columnType);


    }

    

    $('#_nav_bird_eye_view_div').jexcel({
        data: data,
        colHeaders: headers,
        colWidths: widths,
        columns: types,
        oninsertrow : function(obj) { new navDataSetHelper().onInsertNewRow(obj);},
        ondeleterow : function(obj) { new navDataSetHelper().onDeleteRow(obj);},
        onchange: function (obj, cell, val) { new navDataSetHelper().onChangeRow(obj, cell, val); }
    });
    
    $('#_nav_bird_eye_view_div').jexcel('updateSettings', {
        table: function (instance, cell, col, row, val, id) {
            debugger;
            // Number formating
            if (col == 3) {
                // Get text
                txt = $(cell).text();
                // Format text
                txt = numeral(txt).format('0,0.00');
                // Update cell value
                $(cell).html(' $ ' + txt);
            }

            // Odd row colours
            if (row % 2) {
                $(cell).css('background-color', '#edf3ff');
            }

            // Remove controls for the last row
            if (row == 9) {
                if (col < 3) {
                    $(cell).html('');
                }

                if (col == 2) {
                    $(cell).html('Total');
                }

                $(cell).css('background-color', '#f46e42');
                $(cell).css('color', '#fff');
            }
        }
    });
}
