// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Sidebar open/close
function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
document.getElementById("main").style.marginLeft = "250px";
    }

function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
document.getElementById("main").style.marginLeft = "0";
}

//Player
// Toggle custom media player
$('#toggleMediaPlayer').on('click', function () {
    $('#customMediaPlayer').toggleClass('minimized');
});
