// Vanilla JS: Show / Hide Password Toggle
function togglePassword(inputId) {
    const field = document.getElementById(inputId);
    if (field) {
        field.type = field.type === "password" ? "text" : "password";
    }
}

// jQuery Form Validations and Interaction Alerts
$(document).ready(function () {

    // jQuery: Client-side validation on Registration Form submit
    $('#registerForm').on('submit', function (e) {
        let firstName = $('#regFirstName').val().trim();
        let lastName = $('#regLastName').val().trim();
        let email = $('#regEmail').val().trim();
        let password = $('#regPassword').val();
        let confirmPassword = $('#regConfirmPassword').val();
        let alertBox = $('#jsValidationAlert');

        if (!firstName || !lastName || !email || !password || !confirmPassword) {
            e.preventDefault();
            alertBox.removeClass('d-none').text('Alert: All registration fields are required!');
            return false;
        }

        if (password !== confirmPassword) {
            e.preventDefault();
            alertBox.removeClass('d-none').text('Alert: Password and Confirm Password do not match!');
            return false;
        }

        alertBox.addClass('d-none');
    });

    // jQuery: Client-side validation on Login Form submit
    $('#loginForm').on('submit', function (e) {
        let email = $('#loginEmail').val().trim();
        let password = $('#loginPassword').val().trim();
        let alertBox = $('#jsLoginAlert');

        if (!email || !password) {
            e.preventDefault();
            alertBox.removeClass('d-none').text('Alert: Invalid login input! Both Email and Password are required.');
            return false;
        }

        alertBox.addClass('d-none');
    });
});