let iconCart = document.querySelector('.iconCart');
let cart = document.querySelector('.main-cart');
let container = document.querySelector('.movement-container');
let close = document.querySelector('.close');
let navbar = document.querySelector('.navbar');
let dropdown = document.querySelector('.dropdown');
const dotContainer = document.querySelector(".dots");
const preBtn = document.querySelector(".btn_pre");
const nextBtn = document.querySelector(".btn_next");

iconCart.addEventListener('click', function () {
    console.log("ok");
    if (cart.style.right == '-100%') {
        cart.style.right = '0';
        container.style.transform = 'translateX(-200px)';
        navbar.style.transform = 'translateX(-200px)';
    } else {
        cart.style.right = '-100%';
        container.style.transform = 'translateX(0)';
        navbar.style.transform = 'translateX(0)';
    }
})
close.addEventListener('click', function () {
    cart.style.right = '-100%';
    container.style.transform = 'translateX(0)';
    navbar.style.transform = 'translateX(0)';
})

if (dropdown !== null) {
    dropdown.addEventListener('click', () => {
        dropdown.classList.toggle('active');
    })
}

let currentPage = 1;
let maxPage = 5;

if (dotContainer != null) {
    const activateDot = function (page) {
        document.querySelectorAll(".dots__dot").
            forEach(dot => dot.classList.remove("active"));

        document.querySelector('.dots__dot[data-page="' + page + '"]')
            .classList.add('active');
    }

    dotContainer.addEventListener("click", function (e) {
        if (e.target.classList.contains("dots__dot")) {
            const { page } = e.target.dataset;
            activateDot(page);
            currentPage = +page;
        }
    })

    preBtn.addEventListener("click", function () {
        if (currentPage == 1) {
            return;
        }
        const page = currentPage - 1;
        document.querySelectorAll(".dots__dot").
            forEach(dot => dot.classList.remove("active"));

        document.querySelector('.dots__dot[data-page="' + (page) + '"]')
            .classList.add('active');
        currentPage = +page;
    })

    nextBtn.addEventListener("click", function () {
        if (currentPage == maxPage) {
            return;
        }
        const page = currentPage + 1;
        document.querySelectorAll(".dots__dot").
            forEach(dot => dot.classList.remove("active"));

        document.querySelector('.dots__dot[data-page="' + (page) + '"]')
            .classList.add('active');
        currentPage = +page;
    })
}




