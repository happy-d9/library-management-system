
    function addToCart(bookId) {
        $.ajax({
            type: "POST",
            url: "/Home/AddToCart", // Modify the URL as needed
            data: { id: bookId },
            success: function (response) {
                updateBadge(response.cartItemCount);
            },
            error: function () {
                // Handle error if needed
            }
        });
    }

    function updateBadge(cartItemCount) {
        $(".badge").text(cartItemCount);
    }
