function multiplicationTable(n) {
    let output = '<table border="1">\n';
    output += '<tr><th>x</th>'

    for (var i = 1; i <= n; i++) {
        output += `<th>${i}</th>`;
    }

    output += '</tr>\n';

    for (let currentRow = 1; currentRow <= n; currentRow++) {
        output += `<tr><th>${currentRow}</th>`;

        for (var currentCol = 1; currentCol <= n; currentCol++) {
            output += `<td>${currentRow * currentCol}</td>`;
            
        }
        output += '</tr>\n';
    }

    output += '</table>';

    return output;
}

console.log(multiplicationTable(5));