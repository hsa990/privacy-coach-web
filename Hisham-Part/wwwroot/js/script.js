// Password match validation for signup form
document.addEventListener("DOMContentLoaded", () => {
    const signupForm = document.getElementById("signup-form");
    if (signupForm) {
        signupForm.addEventListener("submit", function (e) {
            e.preventDefault();
            const password = document.getElementById("password").value;
            const confirmPassword = document.getElementById("confirmPassword").value;
            const errorMsg = document.getElementById("error-msg");

            if (password !== confirmPassword) {
                errorMsg.textContent = "Passwords do not match.";
            } else {
                errorMsg.textContent = "";
                alert("Signup successful!");
                signupForm.reset();
            }
        });
    }

    // Random privacy tip (on homepage)
    const tipElement = document.getElementById("privacy-tip");
    if (tipElement) {
        const tips = [
            "Avoid reusing passwords on multiple sites.",
            "Enable Two-Factor Authentication on all accounts.",
            "Review app permissions regularly.",
            "Don’t overshare on social media.",
            "Use a password manager for safety."
        ];
        const randomIndex = Math.floor(Math.random() * tips.length);
        tipElement.textContent = tips[randomIndex];
    }
});

// Show/hide password function
function togglePassword(fieldId) {
    const field = document.getElementById(fieldId);
    field.type = field.type === "password" ? "text" : "password";
}
