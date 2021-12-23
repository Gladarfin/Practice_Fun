let images;
addELToImages(images);

function addELToImages(imgs) {
    imgs = document.querySelectorAll(".item");
    imgs.forEach(image => {
        image.addEventListener('dragstart', DragStart);
        image.addEventListener('dragend', DragEnd);
    });
}

let boxes;
addDragAndDrop(boxes);

function addDragAndDrop(elements) {
    elements = document.querySelectorAll(".box, .img-container");
    elements.forEach(box => {
        box.addEventListener('dragenter', DragEnter);
        box.addEventListener('dragover', DragOver);
        box.addEventListener('dragleave', DragLeave);
        box.addEventListener('drop', Drop);
    });
}

const imgContainer = document.getElementById('image-container');

function DragStart(e) {
    //добавляем к данным id переносимого объекта и id его родителя
    e.dataTransfer.setData('text/plain', e.target.id + '|' + e.target.parentNode.id);
    //setTimeout(() => {
    //    e.target.classList.add('hide');
    //}, 0);

}

function DragEnter(e) {
    e.target.classList.add('drag-over');

    CancelDefaultBehavior(e);
}

function DragOver(e) {
    e.target.classList.add('drag-over');

    CancelDefaultBehavior(e);
}

function DragLeave(e) {
    e.target.classList.remove('drag-over');

}

function DragEnd(e) {
    const id = e.dataTransfer.getData('text/plain').split('|')[0];
    // const curElement = document.getElementById(id);
    // curElement.classList.remove('hide');

}

function Drop(e) {
    e.target.classList.remove('drag-over');
    const dropData = e.dataTransfer.getData('text/plain');
    const dropItems = dropData.split('|');
    const prevElem = document.getElementById(dropItems[1]);
    const curElement = document.getElementById(dropItems[0]);
    //нельзя помещать картинку в картинку
    if ((e.target.nodeName != "IMG")) {
        //если переносим из объекта для дропа в объект для дропа, то меняем местами
        if (e.target.childNodes.length == 1 && e.target.className != "img-container") {
            const current = document.getElementById(e.target.firstChild.id);
            prevElem.appendChild(current);
        }
        e.target.appendChild(curElement);
    }

    //перенесен последний элемент?
    if (imgContainer.childElementCount == 0) {
        showNextButton();
    } else if (!nextBtn.classList.contains('hide')) {
        addHideClass(nextBtn);
    }
    CancelDefaultBehavior(e);
}

function CancelDefaultBehavior(e) {
    e.preventDefault();
    e.stopPropagation();
}