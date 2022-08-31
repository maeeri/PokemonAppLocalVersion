const openModalButtons = document.querySelectorAll('[data-modal-target]')
const closeModalButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')
const ordinaryName = document.getElementById("ord-card-name");
const ordinaryId = document.getElementById("ord-card-id");
const rareName = document.getElementById("rare-card-name");
const rareId = document.getElementById("rare-card-id");

//const pakka1 = document.querySelectorAll('.pack1');
//const closeBtn = document.querySelectorAll('.close-button')
//pakka1.addEventListener('click', useFunc)


const rareLuokka = document.querySelectorAll(".rareCard");

const openRarePack = document.querySelectorAll('[data-modal-target]').rareLuokka;

/*openRarePack.addEventListener('click', RareCardShow);*/

const rarePack = document.getElementById("#rareCard");

/*const truefalse = true;*/




    openModalButtons.forEach(button => {
        button.addEventListener('click', () => {
            const modal = document.querySelector(button.dataset.modalTarget)
            openModal(modal)
            gsap.from("#card1", { x: -10000 });
            gsap.from("#card2", { x: -10000, delay: 0.5 });
            gsap.from("#card3", { x: -10000, delay: 1 });
            gsap.from("#card4", { x: -10000, delay: 1.5 });
            gsap.from("#rareCard", { x: -10000, delay: 2 });
            gsap.from("#card5", { x: -10000, delay: 2 });

        })
    })

  
    



/*
openRarePack.forEach(button => {
    button.addEventListener('click', () => {
        const modal = document.querySelector(button.dataset.modalTarget)
        openModal(modal)
        gsap.from("#card1", { x: -10000 });
        gsap.from("#card2", { x: -10000, delay: 0.5 });
        gsap.from("#card3", { x: -10000, delay: 1 });
        gsap.from("#card4", { x: -10000, delay: 1.5 });
        gsap.from("#rareCard", { x: -10000, delay: 2 });
        gsap.from("#card5", { x: -10000, delay: 2 });
    })
})
*/


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

    if (closeBtn.clicked) {
        document.getElementById("modal").reset();
    }
}


function flipCard(card) {
    if (card == null) return
    card.classList.add('active')

}



const erikoisPakka = document.querySelectorAll("rarePakka");
erikoisPakka.addEventListener("click", RareCardShow)


function RareCardShow(card) {
    const testi = document.querySelectorAll(".rareCard");
    document.getElementById("card5").style.display = "none";
    rareName.name = "PCards[4].Name";
    rareId.name = "PCards[4].PokemonId";

    testi.classList.add(".rareCard");
    if (card == null) return
    card.classList.add('active');
    document.getElementById("rareCard").style.display = "block";

    closeModalButtons.forEach(button => {
        button.addEventListener('click',
            () => {
                const modal = button.closest('.modal')
                closeModal(modal)
            });
    });

}



function SetPack(value) {
    document.getElementById("set-pack").value = value;
    console.log(value);
    console.log("setpack");
}

function ButtonEvent(card, value, price) {
    RareCardShow(card);
    SetPack(value);
}

function HideRareCard() {

    document.getElementById("rareCard").style.display = "none";
    ordinaryName.name = "PCards[4].Name";
    ordinaryId.name = "PCards[4].PokemonId";
    closeModalButtons.forEach(button => {
        button.addEventListener('click', () => {
            const modal = button.closest('.modal')
            closeModal(modal)
        })
    })
}


