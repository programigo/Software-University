function getNumbers(input) {
    let pattern = /\d+/g;
    let text ='';

    for (let sentence of input) {
        text += sentence;
    }

    let result = [];

    let match = pattern.exec(text);

    while (match) {
        result.push(match[0]);

        match = pattern.exec(text);
    }

    console.log(result.join(' '));
}

getNumbers(['The300',
'What is that?',
'I think it’s the 3rd movie.',
'Lets watch it at 22:45']);