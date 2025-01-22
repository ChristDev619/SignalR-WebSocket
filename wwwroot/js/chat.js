/**
 * Establishes a SignalR connection with the server and manages real-time chat interactions.
 */

// SignalR Connection Setup
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/chathub") // URL for the SignalR hub
    .build();

/**
 * Handles the incoming messages from the SignalR hub.
 * Adds each message to the message list on the UI.
 * 
 * @param {string} user - The name of the user sending the message.
 * @param {string} message - The content of the message.
 */
connection.on("ReceiveMessage", (user, message) => {
    const li = document.createElement("li");
    li.textContent = `${user}: ${message}`;
    document.getElementById("messagesList").appendChild(li);
});

// Start the SignalR connection
connection.start().catch(err => console.error(err.toString()));

/**
 * Handles the form submission, performs validation, and sends the message
 * to the SignalR hub if the form is valid.
 */
document.getElementById("chatForm").addEventListener("submit", async (event) => {
    event.preventDefault(); // Prevent the default form submission

    const form = event.target;

    // Use jQuery Validation to ensure the form is valid
    if (!$(form).valid()) {
        return; // If invalid, do nothing
    }

    // Collect form data
    const formData = new FormData(form);
    const user = formData.get("User"); // Name of the user
    const message = formData.get("Message"); // Content of the message

    try {
        // Send the message using SignalR
        await connection.invoke("SendMessage", user, message);

        // Clear the form fields and validation errors after successful submission
        clearFormFields(form);
        clearValidationErrors(form);
    } catch (err) {
        console.error("Error sending message:", err.toString());
    }
});

/**
 * Clears all input fields and resets the form.
 * 
 * @param {HTMLFormElement} form - The form element to reset.
 */
function clearFormFields(form) {
    form.reset(); // Resets all input fields in the form
}

/**
 * Clears validation errors for the specified form.
 * 
 * @param {HTMLFormElement} form - The form element whose validation errors should be cleared.
 */
function clearValidationErrors(form) {
    // Remove validation error classes from inputs
    $(form).find(".input-validation-error").removeClass("input-validation-error");

    // Reset validation messages to valid state
    $(form).find(".field-validation-error")
        .removeClass("field-validation-error")
        .addClass("field-validation-valid");
}
