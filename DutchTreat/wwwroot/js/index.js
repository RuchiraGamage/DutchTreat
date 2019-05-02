$(document).ready(function () {

    var x = 10;
    var y = "";


    console.log("Hello world");

    var theForm = $("#backGroundForm");
    theForm.hide();

    var item = document.getElementById("buyItem");
    item.addEventListener("click", function () {
        console.log("Buying the item");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("You have clicked on" + $(this).text());
    });


    var $testLogin = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $testLogin.on("click", function () {
        $popupForm.fadeToggle(1000);
    });
});



