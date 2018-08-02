var newRows = {}, deletedRows = {}, updatedRows = {}, flags = [];

function navDataSetHelper() {
    this.columnNames = [{
        "name" : "id",
        "label": "Id",
        "width": 90,
        "columnType": {
            type: 'hidden'
        }
    },{
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
            },
            "addSearchField": function (parent) {
                $(parent).append('<input type="text" class="form-control" id="_nav_plaintiff_search_field" name="' + this.name + ' " placeholder="Enter ' + this.label + '">');

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
        "width": 115,
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
    var button = $(that);
    event.preventDefault();
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
    this.saveDataSet(button)
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

navDataSetHelper.prototype.saveDataSet = function (button) {
    var body = [];
    var updateData = { "type": "update", "data" : [] },
        newData = { "type": "new", "data": [] },
        deleteData = { "type": "delete", "data": [] };
    debugger;
    formatRequest(newRows, newData);
    formatRequest(updatedRows, updateData);
    formatRequest(deletedRows, deleteData);
    body.push(updateData);
    body.push(newData);
    body.push(deleteData);
    return navRequestHandler().doRequest(button.prop("href"), 'POST', body);
}

function formatRequest(source, destination) {
    for (var key in source) {
        if (source.hasOwnProperty(key)) {
            var temp = {};
            temp["id"] = key;
            for (var key1 in source[key]) {
                if (source[key].hasOwnProperty(key1)) {
                    temp[key1] = source[key][key1];
                }
            }
            destination.data.push(temp);
        }
    }
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

navDataSetHelper.prototype.onInsertNewRow = function (obj, rowNumber) {
    debugger;
    var id = moment().valueOf() + "";
    $($("#row-" + rowNumber).children()[1]).text(id);
    newRows[id] = {};
}

navDataSetHelper.prototype.onDeleteRow = function (obj, rowNumber, numOfRows, records) {
    debugger;
    //var id = $($("#row-" + rowNumber).children()[1]).text();
    var id = records[rowNumber][0];

    if(newRows[id]) {
        newRows[id] = undefined;
        delete newRows[id];
    } else if(updatedRows[id]) {
        updatedRows[id] = undefined;
        delete updatedRows[id];
        deletedRows[id] = {
            "id" : id
        };
    } else {
        deletedRows[id] = {
            "id" : id
        };
    }
}

navDataSetHelper.prototype.onChangeRow = function (obj, cell, val) {
    debugger;
    var id = $($(cell).parent().children()[1]).text();
    var columnNumber = parseInt($(cell).prop("id").split("-")[0]);

    if ((this.columnNames[columnNumber].name == "dateOfFiling") ||
        (this.columnNames[columnNumber].name == "dateOfJudgement")) {
        val = moment(val).valueOf();
    }

    if (newRows[id]) {
        newRows[id][this.columnNames[columnNumber].name] = val;
    } else {
        if (!updatedRows[id]) {
            updatedRows[id] = {};
        }
        updatedRows[id][this.columnNames[columnNumber].name] = val;
    }
}


registerDataSetHandlers();

function registerDataSetHandlers() {
    $("#_nav_bird_eye_view_button").click(function (event) { new navDataSetHelper().dataSetHandler(event, this) });
    var dataset = getData();
    var d = new navDataSetHelper();
    var headers = [], widths = [], types = [];

    for (var i = 0; i < d.columnNames.length; i++) {
        headers.push(d.columnNames[i].label);
        widths.push(d.columnNames[i].width);
        types.push(d.columnNames[i].columnType);
    }

    

    $('#_nav_bird_eye_view_div').jexcel({
        data: dataset,
        colHeaders: headers,
        colWidths: widths,
        columns: types,
        oninsertrow : function(obj, rowNumber) { new navDataSetHelper().onInsertNewRow(obj, rowNumber);},
        ondeleterow: function (obj, rowNumber, numOfRows, records) { debugger; new navDataSetHelper().onDeleteRow(obj, rowNumber, numOfRows, records); },
        onchange: function (obj, cell, val) { new navDataSetHelper().onChangeRow(obj, cell, val); },
        allowDeleteColumn: false,
        allowInsertColumn: false,
        allowManualInsertColumn : false
    });
    
    $('#_nav_bird_eye_view_div').jexcel('updateSettings', {
        table: function (instance, cell, col, row, val, id) {
            /*if(col == 0 &&  !($($(cell).siblings()[0]).prop("id"))) {
                $($(cell).siblings()[0]).prop("id", ids[row]);
            }*/
            
        }
    });
}
