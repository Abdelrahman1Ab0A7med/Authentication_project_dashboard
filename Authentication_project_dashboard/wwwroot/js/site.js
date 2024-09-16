// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let img = document.getElementById('profilepicture').src;//img <== default || stored img 
function changeImage() {
    console.log(window.URL.createObjectURL(this.files[0]));
    document.getElementById('profilepicture').src = window.URL.createObjectURL(this.files[0]);
}
function removeImage() {
    document.querySelector("input[type=file]").value = null;
    if (img == document.getElementById('profilepicture').src) {
        img = "/images/ProfilePicture.png";
        document.getElementById("remvpic").value = "true";
    }
    document.getElementById('profilepicture').src = img;
}