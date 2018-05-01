function calculateMetrix(input) {
    let feets = Math.floor(input / 12);
    let inches = input % 12;

    console.log(`${feets}'-${inches}"`);
}

calculateMetrix(36);