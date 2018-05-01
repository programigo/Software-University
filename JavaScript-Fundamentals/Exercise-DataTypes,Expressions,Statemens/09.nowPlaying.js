function trackInfo(input) {
    let trackName = input[0];
    let artist = input[1];
    let duration = input[2];

    return `Now Playing: ${artist} - ${trackName} [${duration}]`;
}

console.log(trackInfo(['Number One', 'Nelly', '4:09']));