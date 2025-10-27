document.addEventListener('DOMContentLoaded', function() {
    const loginForm = document.querySelector('#authentication-modal form');
    const emailInput = document.getElementById("email");
    const passwordInput = document.getElementById("password");
    const errorDisplay = document.getElementById("loginError");

    if (loginForm) {
        loginForm.addEventListener('submit', function(e) {
            e.preventDefault();
            errorDisplay.classList.add('hidden');
            
            const formData = {
                email: emailInput.value,
                password: passwordInput.value
            };

            fetch("/account/login", {
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