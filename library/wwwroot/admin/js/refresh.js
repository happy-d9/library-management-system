$(document).ready(function () {
    $(".add-to-cart-form").submit(function (event) {
        event.preventDefault(); // Prevent the default form submission

        var formData = $(this).serialize();

        $.ajax({
            type: "POST",
            url: $(this).attr("action"),
            data: formData,
            success: function (response) {
                if (response.success) {
                    // Success: Optionally update cart icon/counter, show notification, etc.
                    console.log("Item added to cart successfully.");
                } else {
                    // Error: Handle error cases
                    console.log("Error adding item to cart.");
                }
            },
            error: function () {
                // Handle AJAX request errors
                console.log("An error occurred while processing the request.");
            }
        });
    });
});