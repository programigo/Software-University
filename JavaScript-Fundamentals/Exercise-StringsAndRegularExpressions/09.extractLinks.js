function extractLinks(input) {
    let pattern = /\bwww\.[a-zA-Z0-9-]+(\.[a-z]+)+\b/g;
    let match;

    for (let sentence of input) {
        while (match = pattern.exec(sentence)) {

            console.log(match[0]);
        }
    }
}

extractLinks(['Join WebStars now for free, at www.web-stars.com\n' +
'You can also support our partners:\n' +
'Internet - www.internet.com\n' +
'WebSpiders - www.webspiders101.com\n' +
'Sentinel - www.sentinel.-ko \n'])