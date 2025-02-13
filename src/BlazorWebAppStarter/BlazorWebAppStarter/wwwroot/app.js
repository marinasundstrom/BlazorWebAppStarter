function initScrollToTop() {
    var scrollToTop = document.querySelector("#scrollToTop");

    if (!scrollToTop) return;

    scrollToTop.addEventListener("click", ev => {
        ev.preventDefault();

        document.documentElement.scrollTo(0, 0);
    });
}

(() => {
    'use strict'

    document.querySelector('#navbarSideCollapse').addEventListener('click', () => {
        document.querySelector('.offcanvas-collapse').classList.toggle('open')
    })
})()

Blazor.addEventListener('enhancedload', () => {
    window.scrollTo({ top: 0, left: 0, behavior: 'instant' });
});

initScrollToTop();