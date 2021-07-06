$(document).ready(function () {
    $('.home-page__slider').slick({
        dots: true,
        infinite: true,
        arrows: false,
        slidesToShow: 1,
        slidesToScroll: 1,
        autoplay:true,
        pauseOnHover: true,
        autoplaySpeed: 5000,
    });

    $('.place-list').slick({
        infinite: false,
        arrows: true,
        slidesToShow: 5,
        slidesToScroll: 1,
    });
    $('.discount__slider').slick({
        infinite: false,
        arrows: true,
        slidesToShow: 3,
        slidesToScroll: 1,
    });

    $('.news-list').slick({
        infinite: false,
        arrows: true,
        slidesToShow: 3,
        slidesToScroll: 1,
    });

    $('.post-list').slick({
        infinite: false,
        arrows: true,
        slidesToShow: 4,
        slidesToScroll: 1,
    });

    $('.detail-products-page__slider').slick({
        infinite: true,
        speed: 300,
        slidesToShow: 1,
        centerMode: true,
        variableWidth: true,
    });
    $('.detail-product__room-sugesst--list').slick({
        infinite: false,
        arrows: true,
        slidesToShow: 4,
        slidesToScroll: 1,
    });
});