﻿const openModalButtons = document.querySelectorAll('[data-modal-target]')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')

openModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = document.querySelector(button.dataset.modalTarget)
        openModal(modal)
        gsap.from("#card1", { x: -10000 });
        gsap.from("#card2", { x: -10000, delay: 0.5 });
        gsap.from("#card3", { x: -10000, delay: 1 });
        gsap.from("#card4", { x: -10000, delay: 1.5 });
        gsap.from("#card5", { x: -10000, delay: 2 });


    })
})

/*overlay.addEventListener('click', () => {
  const modals = document.querySelectorAll('.modal.active')
  modals.forEach(modal => {
    closeModal(modal)
  })
})*/

closeModalButtons.forEach(button => {
    button.addEventListener('click', () => {
        const modal = button.closest('.modal')
        closeModal(modal)
    })
})

function openModal(modal) {
    if (modal == null) return
    modal.classList.add('active')
    overlay.classList.add('active')
    overlay2.classList.add('active')
}

function closeModal(modal) {
    if (modal == null) return
    modal.classList.remove('active')
    overlay.classList.remove('active')
    overlay2.classList.remove('active')
}
