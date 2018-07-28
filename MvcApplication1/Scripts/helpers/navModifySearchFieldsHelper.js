function navModifySearchFieldsHelper() {
}

navModifySearchFieldsHelper.prototype.saveDataHandler = function (event, that) {
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
     submitHandler : self.logIn
    })*/
    $("#_nav_modify_search_field_button").prop('disabled', true);
    var self = this;
    this.saveData(form)
        .then(function (response) {
            self.showSuccess(response.body.body.message);
            //$("#_nav_modify_search_field_success .alert-success").focus();
            $("#_nav_modify_search_field_button").prop('disabled', false);
        })
    .catch(function (error) {
        if (typeof error == "string") {
            self.showError(error);
        } else {
            self.showError(error.body.subMessage);
        }
        $("#_nav_modify_search_field_button").prop('disabled', false);
    });
}

navModifySearchFieldsHelper.prototype.saveData = function (form) {
    var body = form.serialize();
    //console.log(body);
    return navRequestHandler().doRequest(form.attr('action'), 'POST', body);
}

navModifySearchFieldsHelper.prototype.showError = function (message) {
    $("#_nav_modify_search_field_error .alert").text(message);
    $("#_nav_modify_search_field_error").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_modify_search_field_error").offset().top
    }, 'slow');
}

navModifySearchFieldsHelper.prototype.showSuccess = function (message) {
    $("#_nav_modify_search_field_success .alert-success").text(message);
    $("#_nav_modify_search_field_success").removeClass("d-none");
    $('html,body').animate({
        scrollTop: $("#" + "_nav_modify_search_field_success").offset().top
    }, 'slow');
}

navModifySearchFieldsHelper.prototype.hideError = function () {
    $("#_nav_modify_search_field_error .alert-danger").text("");
    $("#_nav_modify_search_field_error").addClass("d-none");
}

navModifySearchFieldsHelper.prototype.hideSuccess = function () {
    $("#_nav_modify_search_field_success .alert-success").text("");
    $("#_nav_modify_search_field_success").addClass("d-none");
}

registerModifySearchFieldHandlers();

function registerModifySearchFieldHandlers() {
    //$("#_nav_forgotpassword").click(resetPassword);
    //$("#_nav_modify_search_field_save_btn").click();
    $("#_nav_modify_search_field_div > form").submit(function (event) { new navModifySearchFieldsHelper().saveDataHandler(event, this) });
}
