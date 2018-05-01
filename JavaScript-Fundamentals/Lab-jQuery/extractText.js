function extractText() {
    let result = [];
    $('#items').find('li').each((index, element) => result.push(element.textContent));
    $('#result').text(result.join(', '));
}