$(document).ready(function () {
    const mainSlider = new Splide('.splide', {
        direction: 'ttb',
        type: 'loop',
        height: '100%',
        width: '100%',
        wheel: true,
        releaseWheel: true,
        gap: 0,
        perPage: 1,
        autoplay: true,
        interval: 4000,
        pauseOnHover: true,
        speed: 800,
        arrows: false,
        pagination: false,
        drag: true,
        cover: true,

        breakpoints: {
            768: {
                height: '50vh',
            },
            480: {
                height: '40vh',
            }
        }
    });

    mainSlider.mount();
});