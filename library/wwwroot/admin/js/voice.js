//document.getElementById('voiceButton').addEventListener('click', function () {
//    const recognition = new SpeechRecognition() || new webkitSpeechRecognition(); // Create a recognition object
//    recognition.lang = 'en-US'; // Set language (change as needed)

//    recognition.onresult = function (event) {
//        const voiceCommand = event.results[0][0].transcript.toLowerCase();

//        if (voiceCommand.includes('add to cart')) {
//            // Perform the action when the trigger phrase is detected
//            console.log('Adding item to cart...');
//            // Add your actual code here
//        }
//    };

//    // Start recognition
//    recognition.start();
//});