function scoreToHtml(input) {
    let output = '<table>\n';
    output += '    <tr><th>name</th><th>score</th></tr>\n';

    let arr = JSON.parse(input);

    for (let element of arr) {
        output += `    <tr><td>${htmlEscape(element.name)}</td><td>${element.score}</td></tr>\n`
    }

    output += '</table>';

    console.log(output);

    function htmlEscape(text) {
        return text.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');
    }
}

scoreToHtml('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');