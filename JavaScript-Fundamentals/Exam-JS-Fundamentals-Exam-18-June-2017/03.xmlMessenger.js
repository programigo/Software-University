function printHtml(message) {
    let pattern = /^<message((?:\s+[a-z]+="[a-zA-Z0-9 .]+")+)>((?:.|\n)+)<\/message>$/g;
    let match = pattern.exec(message);

    let output = '<article>\n';

    if (match) {
        if (match[1].includes(' to') && match[1].includes(' from')) {
            let toPattern = /\b\s*to="([a-zA-Z0-9 .]+)"\s*/g.exec(message);
            let fromPattern = /\s*from="([a-zA-Z0-9 .]+)"\s*/g.exec(message);

            let sender = fromPattern[1];
            let recipient = toPattern[1];

            output += `  <div>From: <span class="sender">${sender}</span></div>\n`;
            output += `  <div>To: <span class="recipient">${recipient}</span></div>\n`;
            output += '  <div>\n';

            let messages = match[2].split('\n');

            for (let message of messages) {
                output += `    <p>${message}</p>\n`;
            }

            output += '  </div>\n';
            output += '</article>';

            console.log(output);

        } else {
            console.log('Missing attributes');
        }
    } else {
        console.log('Invalid message format');
    }
}

printHtml('<message to="UserAlpha" from="UserBeta">Message body</message>');