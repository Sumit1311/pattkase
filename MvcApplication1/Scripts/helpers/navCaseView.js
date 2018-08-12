function navViewCaseInfoHelper() {
}

navViewCaseInfoHelper.prototype.editCaseHandler = function(event, that) {
           var form = $(that);
            event.preventDefault();
    this.hideError();
    this.hideSuccess();
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
            submitHandler : self.registration
           })*/
           $("#_nav_view_case_info_save").prop('disabled', true);
           var self = this;
    this.editCase(form)
        .then(function (response) {
            self.showSuccess(response.body.body.message);
            $("#_nav_view_case_info_success .alert-success").focus();
            $("#_nav_view_case_info_save").prop('disabled', false);
            $("#_nav_view_case_info_edit").removeClass("d-none");
            $("#_nav_view_case_info_save").addClass("d-none");
            self.makeFormReadOnly();
        })
           .catch(function(error){
                   
               if(typeof error == "string") {
                self.showError(error);
               } else {
                self.showError(error.body.subMessage);
               }
               $("#_nav_view_case_info_save").prop('disabled', false);
           });
}

navViewCaseInfoHelper.prototype.editCase= function(form) {
    var body = form.serialize();
    return navRequestHandler().doRequest(form.attr('action'), 'POST', body);
}

navViewCaseInfoHelper.prototype.showError = function(message) {
    $("#_nav_view_case_info_error .alert-danger").text(message);
    $("#_nav_view_case_info_error").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_view_case_info_error").offset().top
    }, 'slow');
}

navViewCaseInfoHelper.prototype.showSuccess = function (message) {
    $("#_nav_view_case_info_success .alert-success").text(message);
    $("#_nav_view_case_info_success").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_view_case_info_success").offset().top
    }, 'slow');
}

navViewCaseInfoHelper.prototype.hideError = function () {
    $("#_nav_view_case_info_error .alert-danger").text("");
    $("#_nav_view_case_info_error").addClass("d-none");
}

navViewCaseInfoHelper.prototype.hideSuccess = function () {
    $("#_nav_view_case_info_success .alert-success").text("");
    $("#_nav_view_case_info_success").addClass("d-none");
}

navViewCaseInfoHelper.prototype.editForm = function () {
    $("#_nav_view_case_info_div input.form-control-plaintext").removeClass("form-control-plaintext").addClass("form-control").prop("readonly", false);
    $("#_nav_view_case_info_div select.form-control-plaintext").removeClass("form-control-plaintext").addClass("custom-select").prop("readonly", false).prop("disabled", false);
    $("#_nav_view_case_info_div textarea.form-control-plaintext").removeClass("form-control-plaintext").addClass("form-control").prop("readonly", false).prop("disabled", false);;
    debugger;
    $("#_nav_view_case_info_div input.form-control.datepicker").prop("disabled", false);
}

navViewCaseInfoHelper.prototype.makeFormReadOnly = function () {
    $("#_nav_view_case_info_div input.datepicker.form-control").prop("disabled", true);
    $("#_nav_view_case_info_div input.form-control").removeClass("form-control").addClass("form-control-plaintext").prop("readonly", true);
    $("#_nav_view_case_info_div select.custom-select").removeClass("custom-select").addClass("form-control-plaintext").prop("readonly", true).prop("disabled", true);
    $("#_nav_view_case_info_div textarea.form-control").removeClass("form-control").addClass("form-control-plaintext").prop("readonly", true).prop("disabled", true);
}

registerViewCaseHandler();

function registerViewCaseHandler() {
    $("#_nav_view_case_info_div > form").submit(function (event) {
        new navViewCaseInfoHelper().editCaseHandler(event, this)
    });
}