


//========== Menu side line effect ============
const menuUserLine = document.querySelector('.user-menu__line')
const menuUserItems = document.querySelectorAll('.user-menu__item')

//hover-event
    menuUserItems.forEach(menuUserItem => {
        menuUserItem.onmouseover = function(){
            menuUserLine.style.top = this.offsetTop + 'px'
            menuUserLine.style.height = this.offsetHeight + 'px'
        }
        menuUserItem.onmouseout = function(){
            menuUserLine.style.top = '0'
            menuUserLine.style.height = '0'
        }
    });


//=========== dropbox evnet ===================
const dropBoxBtns = document.querySelectorAll('.has-dropdown-box')


dropBoxBtns.forEach(dropBoxBtn => {
    dropBoxBtn.onclick = function() {
        //$('.dropdown-box').classList.remove('is-able') 
        this.querySelector('.dropdown-box').classList.toggle('is-able')    
    }
})


// ================== pagination ==============

