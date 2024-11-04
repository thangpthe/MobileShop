// <!-- Scroll to top -->
let btnBackTop = document.querySelector(".backToTop");
let headerBottom = document.querySelector(".header-bottom .container");
let ulElement = document.querySelector(".header-bottom ul");
//window.onscroll = function scrollFunction(){
//  if(document.body.scrollTop > 20 || document.documentElement.scrollTop > 20){
//    btnBackTop.style.display = "block";
//    headerBottom.classList.add("fixed");
//    ulElement.style = "border-radius:0;padding-left:176px;";
//  }
//  else{
//    btnBackTop.style.display = "none";
//    headerBottom.classList.remove("fixed");
//    ulElement.style = "border-radius:8px";
//  }
//}
function backTop() {
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
}

function toggleMenu() {
    const navigation = document.querySelector('.navigation');
    navigation.classList.toggle('show');
}