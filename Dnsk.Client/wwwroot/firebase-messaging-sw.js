importScripts("https://www.gstatic.com/firebasejs/9.22.0/firebase-app.js");
importScripts("https://www.gstatic.com/firebasejs/8.2.5/firebase-messaging.js");

// Initialize Firebase
firebase.initializeApp(
    {
        apiKey: "AIzaSyDfIF8ZL7vXdfXn7ClZfkQj39_2COCnjus",
        projectId: "dnsk-test",
        messagingSenderId: "165691055432",
        appId: "1:165691055432:web:10d77deccb69ed9530a77d",
    });
const fcm = firebase.messaging();

fcm.onBackgroundMessage(function(payload) {
    console.log('[firebase-messaging-sw.js] Received background message ', payload);
    //self.registration.showNotification("YOLO", {silent: true});
});