function createXml(input) {
    let output = '<?xml version="1.0" encoding="UTF-8"?>\n';
    output += '<quiz>\n';

    for (let i = 0; i < input.length; i += 2) {
        let question = input[i];
        let answer = input[i + 1];

        output += renderXml(question, answer);
    }

    output += '</quiz>';

    return output;

    function renderXml(question, answer) {
        let result = '  <question>\n';
        result += `    ${question}\n`;
        result += '  </question>\n';
        result += '  <answer>\n';
        result += `    ${answer}\n`;
        result += '  </answer>\n';

        return result;
    }
}

console.log(createXml(["Who was the forty-second president of the U.S.A.?", "William Jefferson Clinton"]));;