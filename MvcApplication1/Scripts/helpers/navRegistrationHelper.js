function navRegistrationHelper() {
}

navRegistrationHelper.prototype.registrationHandler = function(event, that) {
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
           $("#_nav_register_button").prop('disabled', true);
           var self = this;
    this.registration(form)
        .then(function (response) {
            self.showSuccess(response.body.message);
        })
           .catch(function(error){
                   
               if(typeof error == "string") {
                self.showError(error);
               } else {
                self.showError(error.body.subMessage);
               }
               $("#_nav_register_button").prop('disabled', false);
           });
}

navRegistrationHelper.prototype.registration = function(form) {
    var body = form.serialize();
    return navRequestHandler().doRequest('/Auth/Register', 'POST', body);
}

navRegistrationHelper.prototype.showError = function(message) {
    $("#_nav_register_error .alert-danger").text(message);
    $("#_nav_register_error").removeClass("d-none");
}

navRegistrationHelper.prototype.showSuccess = function (message) {
    $("#_nav_register_success .alert-success").text(message);
    $("#_nav_register_success").removeClass("d-none");
}

navRegistrationHelper.prototype.hideError = function () {
    $("#_nav_register_error .alert-danger").text("");
    $("#_nav_register_error").addClass("d-none");
}

navRegistrationHelper.prototype.hideSuccess = function () {
    $("#_nav_register_success .alert-success").text("");
    $("#_nav_register_success").addClass("d-none");
}