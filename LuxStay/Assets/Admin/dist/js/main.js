$(document).ready(function(){
    $(".btn").off("click").on("click",function(){
          console.log("click");
          playSound("../../dist/mp3/windows_exclamation.mp3");
    });

});
function playSound(url) {
  const audio = new Audio(url);
  audio.play();
}