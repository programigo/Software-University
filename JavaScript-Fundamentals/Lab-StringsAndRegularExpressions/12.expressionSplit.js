function splitInput(text) {
    let splitPattern = /[\s.();,]+/;

    console.log(text.split(splitPattern).join('\n'));
}

splitInput('let sum = 1 + 2;if(sum > 2){\tconsole.log(sum);}');