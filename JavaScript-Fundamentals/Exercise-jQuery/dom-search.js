function domSearch(selector, isCaseSensitive) {
    let htmlElement = $(selector);
    let isSensitiveCase = isCaseSensitive;
    let resultdiv = $('.result-controls')[0];
    let inputField = $('.add-controls')[0].children[0].children[0];
    let addButton = $('.add-controls')[0].children[1];
    let searchField = $('.search-controls')[0].children[0].children[0];
    let allListItems;

    addButton.addEventListener('click', function (event) {
        event.preventDefault();
        let li = $('<li class="list-item"></li>');
        let liButton = $('<a class="button">X</a>');//
        let elementName = $(`<strong>${inputField.value}</strong>`);
        liButton.appendTo(li);
        elementName.appendTo(li);
        li.appendTo(resultdiv);
        allListItems = $('li');
        checkIfXButtonIsClicked();
    });

    searchField.addEventListener('input', function () {
        let searchText = searchField.value;

        if (isSensitiveCase === false) {
           $('li:not(:contains('+ searchText +'))').hide();
        }
    });

    function checkIfXButtonIsClicked() {
        for (let listItem of allListItems.toArray()) {
            let xButton = listItem.children[0];
            let currentElement = xButton.parentNode;

            xButton.addEventListener('click', function (ev) {
                ev.preventDefault();
                currentElement.style.display = 'none';
            })
        }
    }
}