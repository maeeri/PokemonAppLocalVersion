
const fill = document.querySelector('.fill');
const empties = document.querySelectorAll('.kortti');

// Täyttöä 
fill.addEventListener('dragstart', dragStart);
fill.addEventListener('dragend', dragEnd);

// Tyhjien boxien 
for (const kortti of empties) {
    kortti.addEventListener('dragover', dragOver);
    kortti.addEventListener('dragenter', dragEnter);
    kortti.addEventListener('dragleave', dragLeave);
    kortti.addEventListener('drop', dragDrop);
}

// Raahaus funktiot

function dragStart() {
    this.className += ' hold';
    setTimeout(() => (this.className = 'invisible'), 0);
}

function dragEnd() {
    this.className = 'fill';
}

function dragOver(e) {
    e.preventDefault();
}

function dragEnter(e) {
    e.preventDefault();
    this.className += ' hovered';
}

function dragLeave() {
    this.className = 'kortti';
    this.append(empties)
}

function dragDrop() {
    this.className = 'kortti';
    this.append(fill);
}
