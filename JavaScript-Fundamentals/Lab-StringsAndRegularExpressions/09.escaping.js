function escapeText(input) {
let output = '<ul>\n';

    for (let sentence of input) {
        output += `<li>${htmlEscape(sentence)}</li>\n`;
    }

    output += '</ul>';

    console.log(output);

    function htmlEscape(text) {
        return text.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

escapeText(['<b>unescaped text</b>', 'normal text']);