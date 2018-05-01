function search() {
    let searchText = $('#searchText').val();
    let filteredTowns = $(`#towns li:contains(${searchText})`);
    let result = $('#result')

    filteredTowns.css("font-weight","bold");

    result.text(`${filteredTowns.length} matches found.`);
}