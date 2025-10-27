document.addEventListener('DOMContentLoaded', function() {
    const signupForm = document.querySelector('#signup-modal form');
    const emailInput = document.getElementById("email");
    const fullNameInput = document.getElementById("fullName");
    const phoneInput = document.getElementById("phone");
    const passwordInput = document.getElementById("password");
    const errorDisplay = document.getElementById("registerError");

    if (signupForm) {
        signupForm.addEventListener('submit', function(e) {
            e.preventDefault();
            errorDisplay.classList.add('hidden');
            
            const formData = {
                email: emailInput.value,
                phone: phoneInput.value,
                fullName: fullNameInput.value,
                password: passwordInput.value
            };

            fetch("/account/register", {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            })
                .then(response => {
                    if (!response.ok) {
                        errorDisplay.classList.remove('hidden');
                        return;
                    }
                    window.location.reload();
                })
                .catch(error => {
                    errorDisplay.classList.remove('hidden');
                });
        });
    }
});