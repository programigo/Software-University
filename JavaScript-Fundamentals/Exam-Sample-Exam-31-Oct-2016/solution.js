function generateText(selector) {
    let text = $('p strong').toArray().map(st => st.textContent);
    $(selector).on('click', function () {
        let content = $('#content');
        let parent = content.parent();
        let div = $('<div id="summary">');
        let h2 = $('<h2>Summary</h2>');
        let paragraph = $(`<p>${text.join('')}</p>`);
        div.append(h2);
        div.append(paragraph);
        parent.append(div);
    });
}