function printTable(input) {
    let arr = JSON.parse(input);
    let output = '<table>\n';

    output += '    <tr>';

    for (let key of Object.keys(arr[0])) {

        output += `<th>${key}</th>`;
    }

    output += '</tr>\n';

        for (let element of arr) {
            output += '    <tr>';
            let keys = Object.keys(element);
            for (let key of keys) {
                output += `<td>${htmlEscape(element[key])}</td>`
            }
            output += '</tr>\n';
        }

    output += '</table>';

    console.log(output);

    function htmlEscape(text) {
        if (Number(text)){
            return Number(text);
        }
        return text.replace(/&/g, '&amp;')
            .replace(/</g, '&lt;')
            .replace(/>/g, '&gt;')
            .replace(/"/g, '&quot;')
            .replace(/'/g, '&#39;');

    }
}

printTable('[{"Name":"Tomatoes & Chips","Price":2.35},{"Name":"J&B Chocolate","Price":0.96}]');