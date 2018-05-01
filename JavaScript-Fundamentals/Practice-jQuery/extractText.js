function extractText() {
    let allLi = $('li').toArray().map(li => li.textContent).join(', ');
    $('#result').text(allLi);
}