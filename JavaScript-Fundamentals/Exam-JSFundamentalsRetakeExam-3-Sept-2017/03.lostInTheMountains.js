function decryptCoordinates(keyword, text) {
    let coordinatesPattern = /(north|east)\s*[a-zA-Z]*(\d{2})\D*\s*\w*,\D*\s*\w*(\d{6})/gmi;
    let messagePattern = new RegExp(`${keyword}\\s*(.+\\s*.+\\s*)${keyword}`, 'gmi');

    let match;

    while (match = coordinatesPattern.exec(text)) {

    }
}