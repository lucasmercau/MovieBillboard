// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function(){
    var imgs = document.querySelectorAll('img');
    imgs.forEach(function(img) {
        img.onerror = function() {
            this.onerror = null;
            this.src = '/images/missingposter.jpg';
        };
    });
});