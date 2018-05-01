function initializeTable() {
    $('#createLink').click(addCountry);

    createCountry('Bulgaria', 'Sofia');
    createCountry('Germany', 'Berlin');
    createCountry('Russia', 'Moscow');
    fixLinks();

    function fixLinks() {
        $('tr a').show();
        $('tr:last-child a:contains(Down)').hide();
        $('tr:eq(2) a:contains(Up)').hide();
    }

    function addCountry() {
        let name = $('#newCountryText').val();
        let capital = $('#newCapitalText').val();
        createCountry(name, capital);
        fixLinks();
    }

    function createCountry(name, capital) {
       let row = $('<tr>')
            .append($(`<td>${name}</td>`))
            .append($(`<td>${capital}</td>`))
            .append($(`<td>`)
                .append($('<a href="#">[Up]</a>').click(moveUp))
                .append($('<a href="#">[Down]</a>').click(moveDown))
                .append($('<a href="#">[Delete]</a>').click(deleteRow)));

       row.css('display', 'none');

       row.appendTo($('#countriesTable'));

       row.fadeIn();
    }

    function moveUp() {
        let currentRow =  $(this).parent().parent();
        currentRow.fadeOut(() => {
            currentRow.insertBefore(currentRow.prev());
            currentRow.fadeIn();
            fixLinks();
        });
    }

    function moveDown() {
        let currentRow =  $(this).parent().parent();
        currentRow.fadeOut(() => {
            currentRow.insertAfter(currentRow.next());
            currentRow.fadeIn();
            fixLinks();
        });
    }

    function deleteRow() {
        let currentRow =  $(this).parent().parent();
        currentRow.fadeOut(() => {
            $(this).parent().parent().remove();
            currentRow.fadeIn();
            fixLinks();
        });
    }
}