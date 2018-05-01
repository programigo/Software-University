function search() {
    let searchText = $('#searchText').val();
    let matches = 0;
    $('#towns li').each((index, element) => {
        if (element.textContent.includes(searchText)) {
            $(element).css('font-weight', 'bold');
            matches++;
        } else {
            $(element).css('font-weight', '');
        }
    });
    $('#result').text(`${matches} matches found.`)
}