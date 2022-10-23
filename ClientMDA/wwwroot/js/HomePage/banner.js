
////banner
var swiper = new Swiper(".mySwiper", {
    spaceBetween: 30,
    centeredSlides: true,
    autoplay: {
        delay: 1500,
        disableOnInteraction: false,
        pauseOnMouseEnter: 1,

    },
    pagination: {
        el: ".swiper-pagination",
        clickable: true,
    },
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});




/*rate*/
var swiper = new Swiper(".mySwiperRATE", {
    slidesPerView: 4,
    spaceBetween: 30,
    autoplay: {
        delay: 1500,
        disableOnInteraction: false,
        pauseOnMouseEnter: 1,
    },
    pagination: {
        el: ".swiper-paginationR",
        clickable: true,
    },

});

//modal
const openModalButtons = document.querySelectorAll('[data-modal-target]')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')
const headerofstar = document.getElementById("in-rating-movie");

for (let i = 0; i < openModalButtons.length; i++) {
    openModalButtons[i].addEventListener('click', event => {
        const modal = document.querySelector("#modal")
        openModal(modal)
        const f = $(event.currentTarget).parents(".box").find("h5")[0].textContent
        headerofstar.textContent = f

    })
}

overlay.addEventListener('click', () => {
    const modals = document.querySelectorAll('.modalst.active')
    modals.forEach(modal => {
        closeModal(modal)
    })
})

closeModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = button.closest('.modalst')
        closeModal(modal)
    })
})

function openModal(modal) {
    if (modal == null) return
    modal.classList.add('active')
    overlay.classList.add('active')
}

function closeModal(modal) {
    if (modal == null) return
    modal.classList.remove('active')
    overlay.classList.remove('active')
}

//modal2
const openModalButtonsE = document.querySelectorAll('#openbtnE')
const closeModalButtonsE = document.querySelectorAll('#closebtnE')
const overlayE = document.getElementById('overlayE')
const headerofstarE = document.getElementById("in-rating-movieE");

for (let i = 0; i < openModalButtonsE.length; i++) {
    openModalButtonsE[i].addEventListener('click', event => {
        const modal = document.querySelector("#modalE")
        openModal(modal)
        const f = $(event.currentTarget).parents(".box").find("h5")[0].textContent
        headerofstarE.textContent = f
        console.log(f)
    })
}

overlay.addEventListener('click', () => {
    const modals = document.querySelectorAll('.modalstE.active')
    modals.forEach(modal => {
        closeModal(modal)
    })
})

closeModalButtonsE.forEach(button => {
    button.addEventListener('click', () => {
        const modal = button.closest('.modalstE')
        closeModal(modal)
    })
})


//change font
const titles = document.querySelectorAll('h5 a');
for (let i = 0; i < titles.length; i++) {
    if (titles[i].innerText.length >= 9) {
        titles[i].style.fontSize = "1.15rem";

    }
}

/*bookmark*/
const bookmarkadd = document.querySelectorAll('#bookmarkpluss,#bookplusboardinner,#bookplusREy');
const bookmarkbg = document.querySelectorAll('.ipc-watchlist-ribbon__bg-ribbon');

for (let i = 0; i < bookmarkadd.length; i++) {
    bookmarkadd[i].addEventListener('click', event => {
        let add = '✓';

        if (bookmarkadd[i].textContent == add) {
            bookmarkadd[i].textContent = "+";
            bookmarkbg[i].classList.remove('active')
        }
        else {
            bookmarkadd[i].textContent = add;
            bookmarkbg[i].classList.add('active');
        }
    })
}

//swiper
    var swiper = new Swiper(".mySwipersw", {
        effect: "cards",
            /*grabCursor: true,*/
    });

//img click
const img = document.querySelectorAll('#swipersw-slide')

//for (let i = 0; i < img.length; i++) {
//    img[i].addEventListener('click', ev => {
//        console.log('hello')
//        let image = document.createElement('a')
//        console.log(image)
//        image.setAttribute('href', 'https://www.imdb.com/title/tt0926084/?ref_=hm_tpks_tt_t_1_pd_tp1_pbr_ic');
//        ev.target.appendChild(image);
        

//    })
//}
