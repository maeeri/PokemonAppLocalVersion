const progress = document.querySelector('.progress-done');


function ProgressBar(value) {

    progress.style.width = progress.getAttribute('data-done') + `${value}` + '%';
    progress.style.opacity = 1;

    document.querySelectorAll('.progress-text').textcontent = `${value}`
    
}

function ProgressBar2(value) {

    progress.style.width = progress.getAttribute('data-done') + `${value}` + '%';
    progress.style.opacity = 1;

    document.querySelectorAll('.progress-text').textcontent = `${value}`

    
}